

using Dag4_Opgave4.A_Delegate_eventsOgListeners;
using System;

static void WarningToConsole()
{
    Console.WriteLine("Ohhnej pas på");
}

static void Warning2()
{
    Console.WriteLine("Du skal virkelig passe meget på !!!!");
}


PowerPlant p1 = new PowerPlant();
p1.SetwarningSingleCast(WarningToConsole);
//p1.SetwarningSingleCast(Warning2); //eksempel på singecast erstatter tidligere metode. 
p1.HeatUp();


PowerPlant p2 = new PowerPlant();
p2.SetwarningMultiCast(WarningToConsole);
p2.SetwarningMultiCast(Warning2); //eksempel på, at multicast, kan indeholder flere metoder. Se metode der bliver kaldt. 
p2.SetwarningMultiCast(() => Console.WriteLine("For varm med Lambda")); //Smart måde at skrive, en delegate. 
p2.SetwarningMultiCast(() => Console.WriteLine(2 + 2));
p2.HeatUp();







