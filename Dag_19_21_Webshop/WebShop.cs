using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dag_19_21_Webshop
{
    public class WebShop
    {
        List<MessageQueue> MessageQueues= new List<MessageQueue>();

        public WebShop(List<MessageQueue> messageQueues)
        {
            this.MessageQueues = messageQueues;
        }

        public bool forespoergLagerStatus(int vareNummer)
        {
            MessageQueue requestQueue = this.MessageQueues[0];
            MessageQueue replyQueue = this.MessageQueues[1];


            mq.Send(vareNummer);

        }
        
    }
}
