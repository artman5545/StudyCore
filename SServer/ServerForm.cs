using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.Connections.UDP;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.DPSBase.SevenZipLZMACompressor;
using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SServer
{
    public partial class ServerForm : Form
    {
        private static IList<IPEndPoint> clients = new List<IPEndPoint>();
        private static System.Timers.Timer timer;
        [Obsolete]
        public ServerForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            button1.Click += button1_Click;
            this.FormClosing += ServerForm_FormClosing;
            UDPListening();
            timer = new System.Timers.Timer
            {
                Interval = 100,
                AutoReset = true
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            List<DataProcessor> pros = new List<DataProcessor>
            {
                DPSManager.GetDataProcessor<RijndaelPSKEncrypter>()
            };
            Dictionary<string, string> options = new Dictionary<string, string>
            {
                { "RijndaelPSKEncrypter_PASSWORD", "password" }
            };
            NetworkComms.DefaultSendReceiveOptions = new SendReceiveOptions(DPSManager.GetDataSerializer<ProtoSerializer>(), pros, options);

            //NetworkComms.DefaultSendReceiveOptions.DataProcessors.Add(DPSManager.GetDataProcessor<RijndaelPSKEncrypter>());
            //RijndaelPSKEncrypter.AddPasswordToOptions(NetworkComms.DefaultSendReceiveOptions.Options, "password");
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetworkComms.Shutdown();
            timer.Stop();
            timer.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            UDPConnection.SendObject("RegisterServerAddress", "client ip address", new IPEndPoint(IPAddress.Broadcast, 10000));
        }

        /// <summary>
        /// 广播服务端ip地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        /// <summary>
        /// 接受客户端ip地址
        /// </summary>
        [Obsolete]
        private void UDPListening()
        {
            Connection.StartListening(ConnectionType.UDP, new IPEndPoint(IPAddress.Any, 10001));
            NetworkComms.AppendGlobalIncomingPacketHandler<long>("RegisterClientAddress", (packetHeader, connection, address) =>
            {
                var endPoint = new IPEndPoint(address, 10012);
                if (!clients.Any(e => address == e.Address.Address))
                {
                    clients.Add(endPoint);
                    listBox1.Items.Add(endPoint.ToString());
                    TCPListening(endPoint);
                }
                textBox1.Text += $"{DateTime.Now}>> recived client address: {endPoint}\r\n>";

            });
        }

        /// <summary>
        /// 启动服务端tcp监听
        /// </summary>
        /// <param name="endPoint"></param>
        public void TCPListening(IPEndPoint endPoint)
        {
            try
            {
                textBox1.Text += $"{DateTime.Now}>> {endPoint} is listening...\r\n>";
                Connection.StartListening(ConnectionType.TCP, endPoint);
                NetworkComms.AppendGlobalIncomingPacketHandler<Student>("sendstudent", (header, connection, ms) =>
                {
                    connection.SendObject("recivestudent", "success");
                    textBox1.Text += $"{DateTime.Now}>> {ms.GetType().Name}: {JsonConvert.SerializeObject(ms)}\r\n>";
                });
            }
            catch (Exception e)
            {
                textBox1.Text += $"{e.Message}\r\n";
                Connection.StopListening(ConnectionType.TCP, endPoint);
                clients.Remove(endPoint);
            }
        }
    }

    [DataSerializerProcessor(4)]
    public class JSONSerializer : DataSerializer
    {

#if ANDROID || iOS
        [Preserve]
#endif
        private JSONSerializer() { }

        #region ISerialize Members

        /// <inheritdoc />
        protected override void SerialiseDataObjectInt(Stream outputStream, object objectToSerialise, Dictionary<string, string> options)
        {
            if (outputStream == null)
                throw new ArgumentNullException("outputStream");

            if (objectToSerialise == null)
                throw new ArgumentNullException("objectToSerialize");

            outputStream.Seek(0, 0);
            var data = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(objectToSerialise));
            outputStream.Write(data, 0, data.Length);
            outputStream.Seek(0, 0);
        }

        /// <inheritdoc />
        protected override object DeserialiseDataObjectInt(Stream inputStream, Type resultType, Dictionary<string, string> options)
        {
            var data = new byte[inputStream.Length];
            inputStream.Read(data, 0, data.Length);
            return JsonConvert.DeserializeObject(new String(Encoding.Unicode.GetChars(data)), resultType);
        }

        #endregion
    }
    [DataSerializerProcessor(6)]
    public class ProtoSerializer : DataSerializer
    {
        protected override object DeserialiseDataObjectInt(Stream inputStream, Type resultType, Dictionary<string, string> options)
        {
            return ProtoBuf.Serializer.Deserialize(resultType, inputStream);
        }

        protected override void SerialiseDataObjectInt(Stream ouputStream, object objectToSerialise, Dictionary<string, string> options)
        {
            ProtoBuf.Serializer.Serialize(ouputStream, objectToSerialise);
        }
    }
    [ProtoContract]
    public class Student
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public int Age { get; set; }
    }

}
