// See https://aka.ms/new-console-template for more information


static void CalculateAge(DateTime BirthDateInput, out int age)
{
    age = DateTime.Now.Year - BirthDateInput.Year;
}


int age = 0;

CalculateAge(new DateTime(2000 , 11, 10),out age);

Console.WriteLine(age);