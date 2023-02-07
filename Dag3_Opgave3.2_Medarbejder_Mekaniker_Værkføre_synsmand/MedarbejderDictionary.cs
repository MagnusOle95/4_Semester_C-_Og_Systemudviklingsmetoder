using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace Dag3_Opgave3._2_Medarbejder_Mekaniker_Værkføre_synsmand

{
    public class MedarbejderDictionary<TKey>
    {
        private readonly Dictionary<TKey, Medarbejder> _collection = new Dictionary<TKey,Medarbejder>();

        public void AddElement(TKey k, Medarbejder p)
        {
            //Inserts a Medarbejder p into the collection.The function must fail if the key is already occupied by some other element
            if (_collection.ContainsKey(k))
            {
                throw new ArgumentException("Key allerede brugt");
            }
            else
            {
                _collection[k] = p;
            }
        }

        public Medarbejder GetElement(TKey k)
        {
            //Retrieves a Medarbejder identified by the TKey k. If not found then the function returns null.
            if (_collection.ContainsKey(k))
            {
                return _collection[k];
            }
            else
            {
                return null;
            }
        }

        public int Size()
        {
            //Returns the number of elements in the collection.
            return _collection.Count();
        }


    }
}
