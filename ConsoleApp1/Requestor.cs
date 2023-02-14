using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace RequestReplyAnders
{
    public class Requestor
    {
        private MessageQueue requestQueue;
        private MessageQueue replyQueue;

        public Requestor(string requestQueueName, string replyQueueName)
        {
            requestQueue = new MessageQueue(@".\Private$\" + requestQueueName);

            replyQueue = new MessageQueue(@".\Private$\" + replyQueueName);
            replyQueue.MessageReadPropertyFilter.SetAll();
            ((XmlMessageFormatter)replyQueue.Formatter).TargetTypeNames = new string[] { "System.String,mscorlib" };
        }

        public void Send()
        {
            Message requestMessage = new Message();
            requestMessage.Body = "Hello World.";
            requestMessage.ResponseQueue = replyQueue;
            Console.WriteLine("Sending");
            requestQueue.Send(requestMessage);

            Console.WriteLine("Sent request");
            Console.WriteLine("\tTime:       {0}", DateTime.Now.ToString("HH:mm:ss.ffffff"));
            Console.WriteLine("\tMessage ID: {0}", requestMessage.Id);
            Console.WriteLine("\tCorrel. ID: {0}", requestMessage.CorrelationId);
            Console.WriteLine("\tReply to:   {0}", requestMessage.ResponseQueue.Path);
            Console.WriteLine("\tContents:   {0}", requestMessage.Body.ToString());
        }

        public void ReceiveSync()
        {
            Message replyMessage = replyQueue.Receive();

            Console.WriteLine("Received reply");
            Console.WriteLine("\tTime:       {0}", DateTime.Now.ToString("HH:mm:ss.ffffff"));
            Console.WriteLine("\tMessage ID: {0}", replyMessage.Id);
            Console.WriteLine("\tCorrel. ID: {0}", replyMessage.CorrelationId);
            Console.WriteLine("\tReply to:   {0}", "<n/a>");
            Console.WriteLine("\tContents:   {0}", replyMessage.Body.ToString());
        }
    }
}


