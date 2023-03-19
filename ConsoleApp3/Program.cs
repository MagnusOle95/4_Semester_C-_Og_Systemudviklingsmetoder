using System;
using System.Collections.Generic;

public class Person
{
    public string Name;
    public List<string> Cars;

    public Person(string name)
    {
        Name = name;
        Cars = new List<string>();
    }

    public void AddCar(string car)
    {
        Cars.Add(car);
        Console.WriteLine(car + " has been added to " + Name + "'s cars.");
    }
}

