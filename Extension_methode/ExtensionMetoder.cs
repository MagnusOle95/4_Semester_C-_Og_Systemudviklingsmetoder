using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_methode
{
    public static class ExtensionMetoder
    {
        public static Boolean lang(this string str)
        {
            if (str.Length >= 5)
            {
                return true;
            }
            return false;
        }

        public static string AldersGruppe(this Person p)
        {
            if (p.Alder <= 2)
            {
                return "Baby";
            }
            else if (p.Alder <= 12)
            {
                return "Barn";
            }
            else if (p.Alder <= 19)
            {
                return "Teenager";
            }
            else if (p.Alder <= 30)
            {
                return "Ung voksen";
            }
            else if (p.Alder <= 60)
            {
                return "Voksen";
            }
            else
            {
                return "Gammel";
            }
        }
    }
}
