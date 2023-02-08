using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag4_Opgave4._5_spillekort_Enum

{
    public enum Kulør
    {
        Spar,
        Hjerter, 
        Klør,
        Ruder,
    }

    public enum Nummer
    {
        Ace,
        To,
        Tree,
        Fire,
        Fem,
        Seks,
        Syv,
        Otte,
        Ni,
        Ti,
        Knægt,
        Dronning,
        Konge,
    }


    delegate bool FilterCardDelegate(Spillekort spillekort);

    public class Spillekort
    {

        public Kulør Kulør { get; set; }
        public Nummer Nummer { get; set; }

        public Spillekort(Kulør kulør, Nummer nummer) 
        {
            Kulør = kulør;
            Nummer = nummer; 
        }

        public string ToString()
        {
            return Kulør + " " + Nummer;
        }
      
    }
}
