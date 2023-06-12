
using Nedarving_Interfaces_Polymorfi;

Bil bil1 = new Bil("Ford",2014);
Bil Bil2 = new Bil("VW", 2020);
Bil lb1 = new Lastbil("Saab", 2010, 10000);
Bil lb2 = new Lastbil("Volvo", 1982, 7200);

bil1.StartMotor();
lb1.StartMotor();

List<Bil> Billiste = new List<Bil>();
Billiste.Add(bil1);
Billiste.Add(Bil2);
Billiste.Add(lb1);
Billiste.Add(lb2);

foreach (var bil in Billiste)
{
    Console.WriteLine(bil.ToString());
}
    
