
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

// Query methods
IEnumerable<int> resultat = listeAfInt.
    Where(i => i % 2 == 0).
    OrderBy(x => x).
    Select(x => x);

foreach (int item in resultat)
{
    Console.WriteLine(item);
}

Console.WriteLine();

//Query expression
IEnumerable<int> resultat2 = from x in listeAfInt
                             where x % 2 == 0
                             orderby x
                             select x;

foreach (int item in resultat2)
{
    Console.WriteLine(item);
}


//Mellemrum
Console.WriteLine();


//Alle ints med præcis to cifre
// Query methods
IEnumerable<int> resultat3 = listeAfInt.
    Where(i => i.ToString().Length >= 2).
    OrderBy(x => x).
    Select(x => x);

foreach (int item in resultat3)
{
    Console.WriteLine(item);
}




