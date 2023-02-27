using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag8_Opgave1_MinFørste_EF_App.Model
{
    [Table("Person")]
    public class Person
    {
        public int PERSONID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    internal Person(string name, int age) 
        {
            Name= name;
            Age= age;

        }

        public Person() 
        {
        }

        public override string ToString()
        {
            return "Navn:" + Name + " " + " Alder:" + Age;
        }

    }
}
