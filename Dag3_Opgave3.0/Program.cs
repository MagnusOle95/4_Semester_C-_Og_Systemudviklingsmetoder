// See https://aka.ms/new-console-template for more information
using Dag3_Opgave3._0;


Shapes s3 = new Circle(5, 5, 2);
Shapes s4 = new Rectangle(10,10,5,2);

List<Shapes> liste = new List<Shapes>();

liste.Add(s3);
liste.Add(s4);

foreach(Shapes s in liste)
{
    Console.WriteLine(s.ToString());
}