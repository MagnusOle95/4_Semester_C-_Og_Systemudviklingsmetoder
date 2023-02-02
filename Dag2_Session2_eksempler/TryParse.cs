using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2Eksempel
{
    internal class TryParse
    {
        static void Main(string[] args)
        {
            String tekstAtParse = "3x2";
            int result;
            bool virkedeDet =int.TryParse(tekstAtParse, out result);
            Console.WriteLine("Virkede det?" + virkedeDet);
            if (virkedeDet)
            {
                Console.WriteLine("Resultat:" + result);
            }
            Console.ReadLine();
        }

    }
}
