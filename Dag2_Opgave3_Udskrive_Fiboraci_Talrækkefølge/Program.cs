// See https://aka.ms/new-console-template for more information

using System;

while (true)
{
    String talString = Console.ReadLine();
    int IndtastetTal = int.Parse(talString);
    Calc_fibonnaci(IndtastetTal);
}

static void Calc_fibonnaci(int antal)
{
    int[] arr = new int[antal];
    int tal1 = 0;
    int tal2 = 1;

    for (int i = 0; i < antal; i++)
    {
        if (i == 0)
        {
            arr[i] = tal1;
        }
        else if (i == 1)
        {
            arr[i] = tal2;
        }
        else
        {
            int value = arr[i - 2] + arr[i - 1];
            arr[i] = value;
        }

    }

    foreach (int tal in arr)
    {
        Console.Write(tal + ",");
    }
    Console.WriteLine();

}

