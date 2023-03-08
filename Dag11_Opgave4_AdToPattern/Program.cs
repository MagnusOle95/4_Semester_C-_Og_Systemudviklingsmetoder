using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag11_Opgave4_AdToPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Læser og Sender xml fil til checkin Kø
            XElement CheckInFile = XElement.Load(@"CheckedInPassenger.xml");
            Console.WriteLine(CheckInFile.ToString());

            //Opretter objekt af read total luggage. 
            ReadLuggageWeight read = new ReadLuggageWeight();

            //Køre metoden til at read total luggage. 
            XElement nyXml = read.getTotalWeight(CheckInFile);

            //Udskriver afsluttende resultat
            Console.WriteLine();
            Console.WriteLine(nyXml.ToString());

            Console.ReadLine();


        }
    }
}
