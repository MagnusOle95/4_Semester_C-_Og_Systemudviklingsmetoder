using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_DataAccessCore.Model
{
    [Table("School")]
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }

        public School() 
        {
        }

        public School(string schoolName, string city, string countryCode)
        {
            SchoolName = schoolName;
            City = city;
            CountryCode = countryCode;
        }
    }

    
}
