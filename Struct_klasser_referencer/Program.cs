using Struct_klasser_referencer;


Person_Struct personStruct;
personStruct.Name = "John";
personStruct.Age = 30;

Person_Class personClass = new Person_Class();
personClass.Name = "Jane";
personClass.Age = 25;

Console.WriteLine("Struct - Name: " + personStruct.Name + ", Age: " + personStruct.Age);
Console.WriteLine("Class - Name: " + personClass.Name + ", Age: " + personClass.Age);

//Structs er værdityper og indeholder deres værdi direkte.
//dvs. at hver gang du opretter en struct, er det en unik kopi.  

//klasser er reference-typer og indeholder en reference til objekter i hukommelsen.

