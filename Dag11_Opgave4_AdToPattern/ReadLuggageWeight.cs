using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag11_Opgave4_AdToPattern
{
    public class ReadLuggageWeight
    {
        public ReadLuggageWeight() { }

        public XElement getTotalWeight(XElement xmlFile)
        {
            //Finder den samlede vægt på bagage.
            double totalWeight = 0;
            IEnumerable<XElement> luggage = xmlFile.Elements("Luggage");
            foreach(XElement ele in luggage) 
            {
                String s = ele.Element("Weight").Value;
                double total = double.Parse(s,CultureInfo.InvariantCulture);
                totalWeight += total;
            }

            //Tilføjer den til eksisterende xml under passenger fil og retunere den. 
            XElement tempXE = xmlFile.Element("Passenger");
            tempXE.Add(new XElement("totalLuggageWeight", totalWeight));
            return xmlFile;
        }
    }
}
