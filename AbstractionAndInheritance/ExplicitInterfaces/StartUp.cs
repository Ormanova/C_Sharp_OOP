

//<name> <country> <age>
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;

List<Citizen> citizens = new List<Citizen>();
while (true)
{
    string[] input = Console.ReadLine().Split(' ');
    if (input[0] == "End")
    {
        break;
    }
    citizens.Add(new Citizen(input[0], input[1], int.Parse(input[2])));
    
}
foreach (var citizen in citizens)
{
    Console.WriteLine(((IPerson)citizen).GetName());
    Console.WriteLine(((IResident)citizen).GetName());
}