using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace PersonServerAPI.Model
{
    public class Person
    {
        private static int Idcount = 0;
        public int Id { get;}
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() 
        {
            Id = Idcount++;
        }

        public Person(string name,int age)
        {
            Id=Idcount++;
            Name = name;
            Age = age;
        }





    }
}
