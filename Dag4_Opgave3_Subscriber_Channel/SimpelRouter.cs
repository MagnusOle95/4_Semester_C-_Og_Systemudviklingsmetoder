using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dag4_Opgave3_Subscriber_Channel
{
    class SimpleRouter
    {
        protected MessageQueue AirportInformation_To_Router;
        protected MessageQueue Router_To_SAS;
        protected MessageQueue Router_To_KLM;
        protected MessageQueue Router_To_SWA;
        public SimpleRouter(MessageQueue airportInformation_To_Router, MessageQueue router_To_SAS, MessageQueue router_To_KLM, MessageQueue Router_To_SWA)
        {
            this.AirportInformation_To_Router = airportInformation_To_Router;
            this.Router_To_SAS= router_To_SAS;
            this.Router_To_KLM= router_To_KLM;
            this.Router_To_SWA = Router_To_SWA;
            AirportInformation_To_Router.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            AirportInformation_To_Router.BeginReceive();
        }
        private void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;
            Message message = mq.EndReceive(asyncResult.AsyncResult);

            Router_To_SAS.Send(message);
            Router_To_KLM.Send(message);
            Router_To_SWA.Send(message);
            mq.BeginReceive();
        }
    }
}
