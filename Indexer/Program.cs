public class MinListe
{
    private string[] items { get; set; }

    public MinListe(int size)
    {
        items = new string[size];
    }

    // Indexer
    public string this[int index]
    {
        get { return items[index]; }
        set { items[index] = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MinListe Liste = new MinListe(3);

        Liste[0] = "Jens";
        Liste[1] = "Emil";
        Liste[2] = "Karl";

        // Get values using the indexer
        Console.WriteLine(Liste[0]); 
        Console.WriteLine(Liste[1]); 
        Console.WriteLine(Liste[2]);

        Console.WriteLine();

        //Henter med for
        bool færidg = false;
        int index = 0;
        while (index < 3)
        {
            Console.WriteLine(Liste[index]);
            index++;
        }

    }
}
