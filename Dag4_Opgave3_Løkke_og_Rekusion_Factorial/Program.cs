
static int Factorial(int talværdi)
{
    int value = talværdi;
    for(int i = talværdi-1; i >= 1; i--)
    {
        value = value * i;
    }
    return value;
}

static int FactorialRecusiv(int talværdi)
{
    if (talværdi == 1)
    {
        return 1;
    }
    else
    {
        return FactorialRecusiv(talværdi - 1) * talværdi;
    }
}

Console.WriteLine(Factorial(5));

Console.WriteLine(FactorialRecusiv(5));
