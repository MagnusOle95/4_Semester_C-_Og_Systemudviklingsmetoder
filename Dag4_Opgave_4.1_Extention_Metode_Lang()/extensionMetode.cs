using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag4_Opgave_4._1_Extention_Metode_Lang__
{
    public static class extensionMetode
    {
        public static Boolean lang(this string str)
        {
            if (str.Length >= 5)
            {
                return true;
            }
            return false;
        }
    }
}
