using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag_19_21_Webshop
{
    public class Storage
    {
        public List<Product> Products { get; set; }

        public Storage() 
        {
             Products = new List<Product>();
        }

        public void AddProdukt(int vareNummer, string emne, int antalPåLager, double stykPris, string specifikation)
        {
            Product tempProdukt = new Product(vareNummer, emne, antalPåLager, stykPris, specifikation);
            Products.Add(tempProdukt);
        } 

        //Laver en innerclass. 
        public class Product
        {
            public int VareNummer { get; set; }
            public string Emne { get; set; }
            public int AntaPåLager{ get; set; }
            public double StkPris { get; set; }
            public string Specifikation { get; set; }

            public Product(int vareNummer, string emne, int antalPåLager, double stykPris, string specifikation)
            {
                VareNummer= vareNummer;
                Emne= emne;
                AntaPåLager= antalPåLager;
                StkPris= stykPris;
                Specifikation= specifikation;
            }


            
        }
    }


}
