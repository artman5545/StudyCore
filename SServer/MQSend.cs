using ChanJoy.Messaging;
using ChanJoy.Messaging.Model.HisMessage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SServer
{
    public partial class MQSend : Form
    {
        public MQSend()
        {
            InitializeComponent();
        }
        private static object locker = new object();
        private static int index = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            var mqEventPublisher = new RabbitMqEventPublisher("amqp://arrcenmq:arrcen911@59.110.172.150:5672", "");
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Tasks.Task task = new Task(() =>
                {
                    lock (locker)
                    {
                        mqEventPublisher.Publish(new TestMessage()
                        {
                            InstitutionId = Guid.NewGuid(),
                            Content = "test" + DateTime.Now.ToString("yyyyMMddHHmmsss") + "/index=" + (++index)
                        });
                    }
                });
                task.Start();
            }
        }
    }

    public class TestMessage : IHisMessage, IEventMessage
    {
        public Guid InstitutionId { get; set; }
        public string Content { get; set; }
    }
}
