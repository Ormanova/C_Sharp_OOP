using FoodShortage.Models;
using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

List<IBuyer> buyers = new();
int numberPeople = int.Parse(Console.ReadLine());

for (int i = 0; i < numberPeople; i++)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (input.Length == 4)
    {
        string name = input[0];
        int age = int.Parse(input[1]);
        string id = input[2];
        string birthdate = input[3];
        IBuyer citizen = new Citizen(name, age, id, birthdate);
        buyers.Add(citizen);
    }
    else
    {
        string name = input[0];
        int age = int.Parse(input[1]);
        string group = input[2];
        IBuyer rebel =  new Rebel(name,age,group);
        buyers.Add(rebel);
    }
}

string buyer = Console.ReadLine();
while (true)
{
    if (buyer == "End")
    {
        break;
    }
    buyers.FirstOrDefault(b => b.Name == buyer)?.BuyFood();
    buyer = Console.ReadLine();
}
Console.WriteLine(buyers.Sum(b => b.Food));
