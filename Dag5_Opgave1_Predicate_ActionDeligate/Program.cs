
List<int> listeAfInt = new List<int>();
listeAfInt.Add(2);
listeAfInt.Add(6);
listeAfInt.Add(5);
listeAfInt.Add(4);
listeAfInt.Add(10);
listeAfInt.Add(11);
listeAfInt.Add(12);
listeAfInt.Add(20);
listeAfInt.Add(25);
listeAfInt.Add(30);

//Finder alle de lige tal i listen.

//Laver en Predicate. 
List<int> resultat = listeAfInt.FindAll(i => i % 2 == 0);

//Laver Action delegate
resultat.ForEach(i => Console.WriteLine(i));

//Mellemrum
Console.WriteLine();

//Finder det sidste tal over 15
int resultat2 = listeAfInt.FindLast(i => i > 15);
Console.WriteLine(resultat2);

//Mellemrum 
Console.WriteLine();

//Finder index på det sidste tal over 15 
int resultat3 = listeAfInt.FindLastIndex(i => i > 15);
Console.WriteLine(resultat3);




