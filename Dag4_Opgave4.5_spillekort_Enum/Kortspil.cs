using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag4_Opgave4._5_spillekort_Enum
{
    internal class Kortspil
    {
        private List<Spillekort> kortListe = new List<Spillekort>();

        public List<Spillekort> filterCardGame(FilterCardDelegate filter)
        {
            List<Spillekort> filteredeKort = new List<Spillekort>();
            for (int i = 0; i < kortListe.Count; i++)
            {
                if (filter.Invoke(kortListe[i]) == true)
                {
                    filteredeKort.Add(kortListe[i]);
                }

            }
            return filteredeKort;
        }

        //public List<Spillekort> filterCardGame(CardFilter filter)
        //{
        //    List<Spillekort> filteredeKort = new List<Spillekort>();
        //    for (int i = 0; i < kortListe.Count; i++)
        //    {
        //        if (filter.filter(kortListe[i]) == true)
        //        {
        //            filteredeKort.Add(kortListe[i]);
        //        }

        //    }
        //    return filteredeKort;
        //}

        public void addCard(Kulør kulør, Nummer nummer)
        {
            Spillekort sk = new Spillekort(kulør,nummer);
            kortListe.Add(sk);
        }

        public void printDeck()
        {
            foreach (var sk in kortListe)
            {
                Console.WriteLine(sk.ToString());
            }
        }


    }
}
