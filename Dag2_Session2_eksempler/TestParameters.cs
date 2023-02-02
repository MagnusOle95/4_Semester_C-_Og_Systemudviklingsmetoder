using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2Eksempel
{
    internal class TestParameters
    {
        static void Main(string[] args)
        {
            string a1 = "initial";
            F(ref a1);
            Console.WriteLine(a1);
            Console.ReadLine();
        }
        private static void F(ref string a)
        {
            a = "Noget andet";
        }

    }
}
