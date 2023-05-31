using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        
        // Define a collection of Person objects
        List<Person> people = new List<Person>
        {
            new Person { Name = "John", Age = 25, City = "New York" },
            new Person { Name = "Alice", Age = 30, City = "Chicago" },
            new Person { Name = "Bob", Age = 35, City = "Los Angeles" },
            new Person { Name = "Emily", Age = 28, City = "New York" },
            new Person { Name = "David", Age = 40, City = "Chicago" }
        };

        // LINQ query to filter and project the collection
        var filteredPeople = from person in people
                             where person.Age > 30
                             select person.Name;

        // Print the filtered results
        foreach (var name in filteredPeople)
        {
            Console.WriteLine(name);
        }

        //Arbejder med, Lamda expression. 
        Func<int, int> doubleNumber = x => x * 2;
        int result = doubleNumber(5);
        Console.WriteLine(result);  // Output: 10

       
        //Tester metode. 
        addPerson("Lars", 22, "CPH", people);
        addPerson("Bob", 45, "Aarhus", people);

        //Laver en, labda expression. 
        people.ForEach(p => Console.WriteLine(p.Name));


    }
    public static void addPerson(string name, int alder, string city, List<Person> list)
    {
        bool PersonExist = list.Any(p => p.Name == name);
        if (!PersonExist)
        {
            list.Add(new Person{Name = name ,Age = alder, City = city});
        }


    }  
}

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }





