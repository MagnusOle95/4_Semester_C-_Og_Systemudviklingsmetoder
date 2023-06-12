
using LINQ_MEtoder;

List<Person> persons = new List<Person>
{
    new Person { Id = 1, FirstName = "John", LastName = "Doe", Age = 25 },
    new Person { Id = 2, FirstName = "Jane", LastName = "Smith", Age = 30 },
    new Person { Id = 3, FirstName = "Bob", LastName = "Johnson", Age = 45 }
};

List<Adress> addresses = new List<Adress>
{
    new Adress { PersonId = 1, City = "New York" },
    new Adress { PersonId = 2, City = "Los Angeles" },
    new Adress { PersonId = 3, City = "Chicago" }
};


//Query Syntax (forespørgselssyntaks):
var Voksne = from person in persons
            where person.Age > 18
            orderby person.LastName
            select person.FirstName;

foreach (var V in Voksne)
{
    Console.WriteLine(V);
}

Console.WriteLine();


//Method Syntax (metodesyntaks):
var Voksne2 = persons
            .Where(person => person.Age > 18)
            .OrderBy(person => person.LastName)
            .Select(person => person.FirstName);

foreach (var V in Voksne2)
{
    Console.WriteLine(V);
}

Console.WriteLine();


//Where - udvidelsen til filtrering:
var adults = persons.Where(person => person.Age >= 18);

foreach (var V in adults)
{
    Console.WriteLine(V.FirstName + " " + V.LastName);
}

Console.WriteLine();


//OrderBy-udvidelsen til sortering:
var sortedPersons = persons.OrderBy(person => person.LastName);

foreach (var V in sortedPersons)
{
    Console.WriteLine(V.FirstName + " " + V.LastName);
}

Console.WriteLine();


//Select-udvidelsen til transformation:
var names = persons.Select(person => person.FirstName);

foreach (var V in names)
{
    Console.WriteLine(V);
}

Console.WriteLine();


//Join-udvidelsen til sammenføjning:
var result = persons.Join(
    addresses,
    person => person.Id,
    address => address.PersonId,
    (person, address) => new { person.FirstName, address.City });

foreach (var V in result)
{
    Console.WriteLine(V);
}

Console.WriteLine();


//Anonyme objekter:
var result2 = from person in persons
             select new { person.FirstName, person.LastName };

foreach (var V in result2)
{
    Console.WriteLine(V);
}

Console.WriteLine();


//Aggregeringsudvidelser
var count = persons.Count();
var totalAge = persons.Sum(person => person.Age);
var averageAge = persons.Average(person => person.Age);
var maxAge = persons.Max(person => person.Age);
var minAge = persons.Min(person => person.Age);

Console.WriteLine(count);
Console.WriteLine(totalAge);
Console.WriteLine(averageAge);
Console.WriteLine(maxAge);
Console.WriteLine(minAge);