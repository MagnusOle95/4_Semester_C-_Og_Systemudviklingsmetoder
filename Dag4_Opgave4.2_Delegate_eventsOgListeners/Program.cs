

using Dag4_Opgave4.A_Delegate_eventsOgListeners;
using Dag4_Opgave4.A_Delegate_eventsOgListeners;

static void WarningToConsole()
{
    Console.WriteLine("Ohhnej pas på");
}

PowerPlant p1 = new PowerPlant();
p1.Setwarning(WarningToConsole);

p1.HeatUp();


