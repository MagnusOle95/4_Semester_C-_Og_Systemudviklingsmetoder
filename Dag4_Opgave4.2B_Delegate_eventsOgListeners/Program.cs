
using Dag4_Opgave4._2B_Delegate_eventsOgListeners;
using Dag4_Opgave4._2B_Delegate_eventsOgListeners;

static void WarningToConsole()
{
    Console.WriteLine("Ohhnej pas på");
}

static void WarningToConsole2()
{
    Console.WriteLine("Fuck");
}

PowerPlant p1 = new PowerPlant();
p1.Setwarning(WarningToConsole);
p1.Setwarning(WarningToConsole2);

p1.HeatUp();




