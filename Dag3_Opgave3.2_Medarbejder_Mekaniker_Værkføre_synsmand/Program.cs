// See https://aka.ms/new-console-template for more information
using Dag3_Opgave3._2_Medarbejder_Mekaniker_Værkføre_synsmand;
using System.Linq.Expressions;

Console.WriteLine("Hello, World!");

//Opretter Cpr
CprNr cprM2 = new CprNr("1995:9:16","1234");
CprNr cprM3 = new CprNr("2002:12:2", "6666");
CprNr cprM4 = new CprNr("1968:3:4", "9999");

//Opretter adresser. 
Adresse a1 = new Adresse("Solvej", 12);
Adresse a2 = new Adresse("Mikkel", 4);
Adresse a3 = new Adresse("Kim", 2);

//Opretter medarbejdere. 
Medarbejder m2 = new Mekaniker(cprM2,"Frank",a1, 2018, 185);
Medarbejder m3 = new Værkføre(cprM3,"Jens", a2, 2000, 185, 2010, 3500);
Medarbejder m4 = new Synsmand(cprM4,"Hans", a3, 2005, 50);

List<Medarbejder> liste = new List<Medarbejder>();

liste.Add(m2);
liste.Add(m3);
liste.Add(m4);

foreach (Medarbejder m in liste)
{
    Console.WriteLine(m.ToString());
}

Console.WriteLine("Mekaniker ugeløn: " + m2.BeregnUgeLøn());
Console.WriteLine("Værkføre ugeløn: " + m3.BeregnUgeLøn());
Console.WriteLine("Synsmand ugeløn: " + m4.BeregnUgeLøn());

Console.WriteLine();

//Laver bibliotek, og afprøver metoder. 
MedarbejderDictionary<Adresse> listeAfMedarbejdere = new MedarbejderDictionary<Adresse>();

listeAfMedarbejdere.AddElement(m2.Adress,m2);
listeAfMedarbejdere.AddElement(m3.Adress, m3);
listeAfMedarbejdere.AddElement(m4.Adress, m4);

int antal = listeAfMedarbejdere.Size();
Console.WriteLine(antal);

object m1FromList = listeAfMedarbejdere.GetElement(m2.Adress);
Console.WriteLine(m1FromList);

//Laver firma og prøver at indsætte, dette i listen. 
Adresse a4 = new Adresse("Magnus",22);
Firma firma = new Firma(a4);
listeAfMedarbejdere.AddElement(firma.Adress, firma);

int antalEfterFirma = listeAfMedarbejdere.Size();
Console.WriteLine(antalEfterFirma);

object firmaFromList = listeAfMedarbejdere.GetElement(a4);
Console.WriteLine(firmaFromList);


