
using Generiske;

Person p = new Person();
p.age = 1;
p.name = "Test";

Person p2 = new Person();
p2.age = 99;
p2.name = "Frank";


liste<Person> liste = new liste<Person>();

liste.Add(p);
liste.Add(p2);

Console.WriteLine(liste.Get(0).name);
Console.WriteLine(liste.Get(1).name);

Console.WriteLine();

liste<string> listeString = new liste<string>();
listeString.Add("Hans");
listeString.Add("Jens");

Console.WriteLine(listeString.Get(0));
Console.WriteLine(listeString.Get(1));





