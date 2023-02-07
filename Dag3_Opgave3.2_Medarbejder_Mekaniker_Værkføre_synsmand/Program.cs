// See https://aka.ms/new-console-template for more information
using Dag3_Opgave3._2_Medarbejder_Mekaniker_Værkføre_synsmand;

Console.WriteLine("Hello, World!");

//Opretter Cpr
CprNr cprM2 = new CprNr("1995:9:16","1234");
CprNr cprM3 = new CprNr("2002:12:2", "6666");
CprNr cprM4 = new CprNr("1968:3:4", "9999");

//Opretter medarbejdere. 
Medarbejder m2 = new Mekaniker(cprM2,"Frank", "Oles vej", 2018, 185);
Medarbejder m3 = new Værkføre(cprM3,"Jens", "Jennergade", 2000, 185, 2010, 3500);
Medarbejder m4 = new Synsmand(cprM4,"Hans", "Geovej", 2005, 50);

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
MedarbejderDictionary<CprNr> listeAfMedarbejdere = new MedarbejderDictionary<CprNr>();

listeAfMedarbejdere.AddElement(m2.CprNummer,m2);
listeAfMedarbejdere.AddElement(m3.CprNummer, m3);
listeAfMedarbejdere.AddElement(m4.CprNummer, m4);

int antal = listeAfMedarbejdere.Size();
Console.WriteLine(antal);

Medarbejder m1FromList = listeAfMedarbejdere.GetElement(cprM2);
Console.WriteLine(m1FromList);
