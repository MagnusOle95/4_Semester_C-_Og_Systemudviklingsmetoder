
// See https://aka.ms/new-console-template for more information
static int UdregnTal(int tal, int expotentiel)
{
    int sum = tal;
    for (int i = 1;i < expotentiel; i++)
    {
        sum = sum * tal;
    }
    return sum;
}

Console.WriteLine(UdregnTal(10, 5));
