using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.Connections.UDP;
using NetworkCommsDotNet.DPSBase;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NetworkCommsDotNet.DPSBase.SevenZipLZMACompressor;

namespace SClient
{
    public partial class ClientForm : Form
    {

        private static IPEndPoint ServerEndPoint;

        [Obsolete]
        public ClientForm()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
            this.Load += Form1_Load;
            this.button1.Click += Button1_Click;
            this.FormClosing += ClientForm_FormClosing;
            List<DataProcessor> pros = new List<DataProcessor>
            {
                DPSManager.GetDataProcessor<RijndaelPSKEncrypter>()
            };
            Dictionary<string, string> options = new Dictionary<string, string>
            {
                { "RijndaelPSKEncrypter_PASSWORD", "password" }
            };
            NetworkComms.DefaultSendReceiveOptions = new SendReceiveOptions(DPSManager.GetDataSerializer<ProtobufSerializer>(), pros, null);
            RijndaelPSKEncrypter.AddPasswordToOptions(NetworkComms.DefaultSendReceiveOptions.Options, "password");
            NetworkComms.DefaultSendReceiveOptions.DataProcessors.Add(DPSManager.GetDataProcessor<RijndaelPSKEncrypter>());
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetworkComms.Shutdown();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ConnectionInfo connection = new ConnectionInfo(ServerEndPoint);
            TCPConnection tcp = TCPConnection.GetConnection(connection);
            var s = new Student
            {
                Name = "AAA",
                Age = new Random().Next(0, 100)
            };
            var result = tcp.SendReceiveObject<Student, String>("sendstudent", "recivestudent", 5000, s);
            textBox1.Text += $"{DateTime.Now}>> student data is send:{result}\r\n>";
        }

        [Obsolete]
        private void Form1_Load(object sender, EventArgs e)
        {
            Connection.StartListening(ConnectionType.UDP, new IPEndPoint(IPAddress.Any, 10000));

            NetworkComms.AppendGlobalIncomingPacketHandler<string>("RegisterServerAddress", (packetHeader, connection, incomingString) =>
            {
                try
                {
                    if (ServerEndPoint == null)
                    {
                        var serverEndPoint = (IPEndPoint)connection.ConnectionInfo.RemoteEndPoint;
                        var clientEndPoint = (IPEndPoint)connection.ConnectionInfo.LocalEndPoint;
                        //此端口tcp用
                        ServerEndPoint = new IPEndPoint(serverEndPoint.Address, 10012);
                        button1.Enabled = true;
                        button1.Text = $"TCP:{ServerEndPoint}";
                        textBox1.Text += $"{DateTime.Now}>> server {ServerEndPoint} request connect.\r\n>";

                        textBox1.Text += $"{DateTime.Now}>> {clientEndPoint.Address} to {ServerEndPoint.Address} port:10001.\r\n>";

                        //connection.SendObject<long>("SendClientAddress", clientip);
                        UDPConnection.SendObject("RegisterClientAddress", clientEndPoint.Address.Address, new IPEndPoint(ServerEndPoint.Address, 10001));
                    }
                }
                catch (Exception ex)
                {
                    textBox1.Text += $"client error:{ex.Message}";
                }
            });
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

    [ProtoContract]
    public class Student
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public int Age { get; set; }
    }
}
