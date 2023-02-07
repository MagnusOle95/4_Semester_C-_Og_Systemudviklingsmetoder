// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Hello, World!");

Time tid = new Time(20,42,20);

Console.WriteLine("Timer: " + tid.Hours);
Console.WriteLine("Minutter: " + tid.Minutes);
Console.WriteLine("Sekunder: " + tid.Seconds+ "\n");

Console.Write(tid.ToString() + "\n");

public struct Time
{
    private int seconds;

    public Time(int hours, int minutes, int seconds)
    {
        this.seconds = hours * 3600 + minutes * 60 + seconds;
    }

    public int Hours
    {
        get { return seconds / 3600; }
    }

    public int Minutes
    {
        get { return (seconds % 3600) / 60; }
    }

    public int Seconds
    {
        get { return seconds % 60; }
    }

    public override string ToString()
    {
        return string.Format("{0:D2}:{1:D2}:{2:D2}", Hours, Minutes, Seconds);
    }
}