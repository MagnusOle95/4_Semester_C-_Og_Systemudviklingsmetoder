
using Dag5_Opgave3_Datahåndtering_MedOgUden_LinkQ;
using System;
using System.Runtime.ConstrainedExecution;
using static System.Formats.Asn1.AsnWriter;

public class program
{
    static List<Person> people1 = new List<Person>();
    static int index = 0; //Bruges til at finde den rette i konsollen. ud fra index. 

    static void Main(string[] args)
    {
        //Laver liste. 
        Exercise1();
        
        //Printer liste ud. 
        foreach (Person person in people1) 
        {
            Console.WriteLine("index: " + index + " " + person.ToString());
            index++;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Opgave 5.3 FindAll

        ////////////////////////////////////////////////////////////////////////////
        Console.WriteLine();
        Console.WriteLine("Printer alle med en score under 2");

        //laver list med Alle personer med en score under 2
        List<Person> scoreUnderTo = people1.FindAll(i => i.Score < 2);

        //Printer denne liste. 
        scoreUnderTo.ForEach(i => Console.WriteLine(i.ToString()));

        ////////////////////////////////////////////////////////////////////////////
        Console.WriteLine();
        Console.WriteLine("Printer alle med lige score");

        //Laver liste med Alle personer med en lige score, altså 0, 2, 4, 6…
        List<Person> personerMedLigeScore = people1.FindAll(i => i.Score % 2 == 0 && i.Score != 0);

        //Printer denne liste. 
        personerMedLigeScore.ForEach(i => Console.WriteLine(i.ToString()));

        ////////////////////////////////////////////////////////////////////////////
        Console.WriteLine();
        Console.WriteLine("Printer alle med lige score og vægt over 60 ");

        //Laver liste med Alle personer med en lige score og weight større end 60
        List<Person> personerLigeScoreVægtStøreEndTre = people1.FindAll(i => i.Score % 2 == 0 && i.Weight > 60);

        //Printer denne liste
        personerLigeScoreVægtStøreEndTre.ForEach(i => Console.WriteLine(i.ToString()));

        ////////////////////////////////////////////////////////////////////////////
        Console.WriteLine();
        Console.WriteLine("Printer alle med en vægt deleligt med 3");

        //Laver liste med Alle personer med en vægt deleligt med 3
        List<Person> PersonerVægtDeleligtTree = people1.FindAll(i => i.Weight % 3 == 0.0);

        //Printer denne liste.
        PersonerVægtDeleligtTree.ForEach(i => Console.WriteLine(i.ToString()));


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Opgave 5.4 FindIndex

        ////////////////////////////////////////////////////////////////////////////
        Console.WriteLine();
        Console.WriteLine("Printer index på den første person med en score på præcis 3");

        //Brug FindIndex metoden på listen til at finde index på den første person med en score på præcis 3.
        int IndexFørst3 = people1.FindIndex(i => i.Score == 3);
        Console.WriteLine(IndexFørst3);


        ////////////////////////////////////////////////////////////////////////////
        Console.WriteLine();
        Console.WriteLine("Printer index på den første person under 10 år, som har en score på 3");

        // Brug FindIndex til at finde index på den første person under 10 år, som har en score på 3.
        int IndexFørste10ÅRScore3 = people1.FindIndex(i => i.Age < 10 && i.Score == 3);
        Console.WriteLine(IndexFørste10ÅRScore3);


        ////////////////////////////////////////////////////////////////////////////
        Console.WriteLine();
        Console.WriteLine("Printer Hvor mange personer er der under 10 år som har en score på 3");

        //Hvor mange personer er der under 10 år som har en score på 3? (Hint: Her skal du bruge FindAll…)
        int PUnder10Score3 = people1.FindAll(i => i.Age < 10 && i.Score == 3).Count();
        Console.WriteLine(PUnder10Score3);

        ////////////////////////////////////////////////////////////////////////////
        Console.WriteLine();
        Console.WriteLine("printer index på den første personer under 8 år, med en score på 3.Bemærk return value her – hvad betyder dette ?");

        //Brug FindIndex til at finde index på den første personer under 8 år, med en score på 3.Bemærk return value her – hvad betyder dette ?
        int IndexPUnder8Score3 = people1.FindIndex(i => i.Age < 8 && i.Score == 3);
        Console.WriteLine(IndexPUnder8Score3);

        //Index -1 betyder at der ikke findes en person med disse kriteríer i listen, og derfor ikke kan finde et index. 


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Opgave 5.6 Extntion metode. 
        Console.WriteLine();
        Console.WriteLine("Har lavet extention metode der aceptere ud fra en predicate");

        //Laver en extention metode der acceptere ud fra predicate. 
        people1.SetAcceptedP(p => p.Score >= 6 && p.Age <= 40);
        people1.ForEach(i=> Console.WriteLine(i.ToString()));


    }


    private static void Exercise1()
    {
        try
        {
            people1 = Person.ReadCSVFile(@"D:\programmering\4_Semester_C-_Og_Systemudviklingsmetoder\Dag5_Opgave3_Datahåndtering_MedOgUden_LinkQ\data1.csv");
        }
        catch (Exception ex)
        {
            Console.WriteLine("EXCEPTION: " + ex.Message);
            Console.WriteLine("You should probably set the filename to the Person.ReadCSVFile method to something on your disk!");
        }
    }

}