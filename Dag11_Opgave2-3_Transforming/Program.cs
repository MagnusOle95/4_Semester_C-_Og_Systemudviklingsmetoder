using Dag11_Opgave2_3_Transforming.Translater_To_Canonical___Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dag11_Opgave2_3_Transforming
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Opretter kør.
            //MessageQueue.Create(@".\Private$\Dag11_Opg3_SasToSasTranslater");
            //MessageQueue.Create(@".\Private$\Dag11_Opg3_OutSasTranslater");
           

            //Forbinder til køerne. 
            MessageQueue sasToSasTranslater = new MessageQueue(@".\Private$\Dag11_Opg3_SasToSasTranslater");
            MessageQueue outSasTranslater = new MessageQueue(@".\Private$\Dag11_Opg3_OutSasTranslater");

            //oprette translater
            SAS_Translator sasTrans = new SAS_Translator(sasToSasTranslater,outSasTranslater);

            //Opretter flyinformation 
            SasFlyinformation sasF1 = new SasFlyinformation("SAS","SK239","JFK","CPH","D","6. Marts 2017","16:45");
            sasToSasTranslater.Send(sasF1);

            Console.ReadLine();
        }
    }
}
