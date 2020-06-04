using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listening();
        }

        public void Listening()
        {
            Connection.StartListening(ConnectionType.UDP, new IPEndPoint(IPAddress.Any, 10000));
            //处理UDP数据
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("ChatMessage", (packetHeader, connection, incomingString) =>
             {
                 textBox1.Text += "\n ... Incoming message from {connection.ToString() } saying '{ incomingString }'.";
             });
        }
    }
}
