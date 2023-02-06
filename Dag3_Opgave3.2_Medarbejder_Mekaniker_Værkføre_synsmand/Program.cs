// See https://aka.ms/new-console-template for more information
using Dag3_Opgave3._2_Medarbejder_Mekaniker_Værkføre_synsmand;

Console.WriteLine("Hello, World!");

Medarbejder m2 = new Mekaniker("Frank", "Oles vej", 2018, 185);
Medarbejder m3 = new Værkføre("Jens", "Jennergade", 2000, 185, 2010, 3500);
Medarbejder m4 = new Synsmand("Hans", "Geovej", 2005, 50);

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

//Hej med dig :D
