namespace Dag16_Opgave2_Partial_view_og_View_component.Models
{
    public class Person
    {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person(string navn, int alder)
            {
                Name = navn;
                Age = alder;
            }
        public Person() { }
     }
    
}
