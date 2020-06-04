using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworkCommsDotNet;
using Google.Protobuf;
using NetworkCommsDotNet.Connections.UDP;
using System.Net;

namespace SocketClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            UDPConnection.SendObject("ChatMessage", "This is the broadcast test message!", new IPEndPoint(IPAddress.Broadcast, 10000));
        }
    }
}
