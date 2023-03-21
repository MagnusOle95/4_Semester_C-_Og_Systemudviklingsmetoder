using System.Text;
using System.Messaging;

namespace BluffCityReceiver
{
    class Program
    {
        static void Main(string[] args)
        {

            MessageQueue messageQueue = null;
            if (MessageQueue.Exists(@".\Private$\PollingQueue"))
            {
                messageQueue = new MessageQueue(@".\Private$\PollingQueue");
                messageQueue.Label = "Polling Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\PollingQueue");
                messageQueue = new MessageQueue(@".\Private$\PollingQueue");
                messageQueue.Label = "Ny oprettet Polling Queue";
            }

            messageQueue.Receive();
        }
    }
}

