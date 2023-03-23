using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Html_generation_CORE.Models
{
    public enum Values
    {
        v1 = 1,
        v2 = 2,
        v3 = 3,
        v4 = 4
    }
    public class Person
    {
        public String Fornavn { get; set; }
        public int Alder { get; set; }
        [DataType(DataType.Date)]
        public DateTime Dato { get; set; }
        [EnumDataType(typeof(Html_generation_CORE.Models.Values))]
        public Values Value { get; set; }
        public bool? rigtigt { get; set; }

        public String 
            email { get; set; }
        private List<String> _Graass = new List<string>(new String[] { "Ole", "hans" });
        public List<String> Graass { get { return _Graass; } set { } }
    }
}