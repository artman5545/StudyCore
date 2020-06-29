using ChanJoy.Messaging;
using ChanJoy.Messaging.Model.HisMessage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SClient
{
    public partial class MQRecive : Form
    {
        public MQRecive()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Load += MQRecive_Load;
        }

        private void MQRecive_Load(object sender, EventArgs e)
        {
            var mqRecive = new RabbitMqEventConsumer("amqp://arrcenmq:arrcen911@59.110.172.150:5672", "");
            mqRecive.HandleEvent<TestMessage>();
            mqRecive.MessageReceived += MqRecive_MessageReceived;
        }

        private void MqRecive_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            var msg = e.Message as TestMessage;
            textBox1.Text += "TestMessage:" + DateTime.Now + JsonConvert.SerializeObject(msg) + "\r\n";
        }
    }
    public class TestMessage : IHisMessage, IEventMessage
    {
        public Guid InstitutionId { get; set; }
        public string Content { get; set; }
    }
}
