using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_DTOCore.Model
{
    public class School
    {
        public School(string schoolName, string city, string countryCode)
        {
            SchoolName = schoolName;
            City= city;
            CountryCode= countryCode;
        }

        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }

        public override string ToString()
        {
            return SchoolName;
        }

    }
}
