using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dag_19_21_Webshop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Opretter kør. 
            MessageQueue.Create(@".\Private$\WebsiteToLayer");
            MessageQueue.Create(@".\Private$\LayerToWebsite");

            //Opretter forbindelse
            MessageQueue WebsiteToLayer = new MessageQueue(@".\Private$\WebsiteToLayer");
            MessageQueue LayerToWebsite = new MessageQueue(@".\Private$\LayerToWebsite");

            //Tilføjer messageQueues til array. 
            List<MessageQueue> MessageQueues = new List<MessageQueue>();
            MessageQueues.Add(WebsiteToLayer);
            MessageQueues.Add(LayerToWebsite);

            //Opretter afdelinger
            Storage storage = new Storage();
            WebShop webshop = new WebShop(MessageQueues);

            //Opretter vare til lager. 
            storage.AddProdukt(12345, "Tv2000", 10, 1999.95, "Godt og robust tv");
            storage.AddProdukt(47784, "vr-kaffesmager", 4, 599.95, "super nedern oplevelse");

            //Website forspørger lager, om status. 
            


        }
    }
}
