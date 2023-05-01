using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag4_Opgave4._5_spillekort_Enum
{
    public interface CardFilter
    {
        bool filter(Spillekort spillekort);
    }
}

