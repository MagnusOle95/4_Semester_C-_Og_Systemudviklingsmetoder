
using Dag4_Opgave4._5_spillekort_Enum;

//Opretter deck
Kortspil deck = new Kortspil();

//Tilføjer kort til decket.

for (int i = 0; i < 4; i++)
{
    for(int j = 0; j< 13; j++)
    {
        deck.addCard((Kulør) i, (Nummer) j);
    }
}

//Printer decket. 
deck.printDeck();

//Laver filter by klør
static bool FilterByKlør(Spillekort spillekort)
{
    if (spillekort.Kulør == Kulør.Klør)
        return true;
    else
        return false;
}

List<Spillekort> kulørListe = deck.filterCardGame(FilterByKlør);

foreach (Spillekort sk in kulørListe)
{
    Console.WriteLine(sk.ToString());
}


