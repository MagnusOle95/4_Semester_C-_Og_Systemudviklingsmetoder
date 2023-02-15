using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag5_Opgave3_Datahåndtering_MedOgUden_LinkQ
{
    static class Opgave5_6_PredicateExtentionMetode
    {
        public static void SetAcceptedP(this List<Person> lst, Predicate<Person> pred) 
        {
            List<Person> result = lst.FindAll(pred);
            foreach (Person p in result) 
            {
                p.Accepted = true;
            }
        }

    }
}
