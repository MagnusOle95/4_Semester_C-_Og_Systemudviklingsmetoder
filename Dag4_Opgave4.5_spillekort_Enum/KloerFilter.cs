using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag4_Opgave4._5_spillekort_Enum
{
    internal class KloerFilter : CardFilter
    {
        public bool filter(Spillekort spillekort)
        {
            if (spillekort.Kulør == Kulør.Klør)
                return true;
            else
                return false;
        }
    }
}
