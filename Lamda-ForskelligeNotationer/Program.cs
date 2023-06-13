
//Enkelt parameter uden parenteser
//Action agere som void.
Action<int> Areal = x => Console.WriteLine(x * x);
Areal(5);


Action<int> Areal3 = x =>
{
    Console.WriteLine(x * x);
};
Areal(4);


//Parameterliste og pilnotering
//Func agere som normal function med retur.
Func<int, int, int> add = (x, y) => x + y;
int result = add(3, 4);
Console.WriteLine(result);


Func<int, int, int> add2 = (x, y) => {
    return x + y;
};

int result2 = add2(5, 5);
Console.WriteLine(result2);




//Lambda-udtryk uden parametre:
Action HelloWorld = () => Console.WriteLine("Hello, World!");
HelloWorld();

//Lambda-udtryk med en enkelt parameter:
Action<int> printUd = x => Console.WriteLine($"Værdien er: {x}");
printUd(100);

//Lambda-udtryk med flere parametre:
Action<int, int> beregnSum = (x, y) => Console.WriteLine($"Summen af {x} og {y} er: {x + y}");
beregnSum(10, 5);

//Lambda-udtryk med implicit returværdi:
Func<int, double, string> d = (x, dY) => x * dY + " Se Resultat"; 
string resultat = d(10,7.5);
Console.WriteLine(resultat);

//Lambda - udtryk med eksplicit returværdi:
Func<int, double, string> d2 = (x, dY) =>
{
    return x * dY + " Se Resultat";
};

string resultat2 = d2(10, 3.33);
Console.WriteLine(resultat2);

