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
                             orderby person.Name descending
                             select person.Name;

        // Print the filtered results
        foreach (var name in filteredPeople)
        {
            Console.WriteLine(name);
        }
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

