// See https://aka.ms/new-console-template for more information
using MyLibrary;
using System;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");
Person person = new Person("martin");
Console.WriteLine(person);
person.Name = "Benny";
Console.WriteLine(person);

Animal hund = new Animal("hund");
Console.WriteLine("Er hunden en hund?: " + hund.isDog());

Animal kat = new Animal("kat");
Console.WriteLine("Er katten en hund?: " + kat.isDog());


//while (true)
//{
//    string indtastetRace;
//    indtastetRace = Console.ReadLine();
//    Animal dyr = new Animal(indtastetRace);
//    Console.WriteLine(dyr);
//}

//Opgave 6
var list = new Liste();
list.addNumber(1);
list.addNumber(10);
list.addNumber(100);
list.PrintNumbers();

Console.WriteLine(); //Mellemrum 

//Opgave 7 
var list_Random = new Liste_random();
list_Random.PrintNumbers();




