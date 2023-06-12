int day = 3;
string dayName;

switch (day)
{
    case 1:
        dayName = "Monday";
        break;
    case 2:
        dayName = "Tuesday";
        break;
    case 3:
        dayName = "Wednesday";
        break;
    case 4:
        dayName = "Thursday";
        break;
    case 5:
        dayName = "Friday";
        break;
    default:
        dayName = "Invalid day";
        break;
}

Console.WriteLine("The day is: " + dayName);

//switch når du skal håndtere en enkelt variabel og sammenligne dens værdi med flere mulige cases.

//if, når du har komplekse betingelser, der skal evalueres


int count = 0;

while (count < 5)
{
    Console.WriteLine("Tal: " + count);
    count++;
}

