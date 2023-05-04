

using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingSpree.Models;

List<Person> people = new();
List<Product> products = new();


try
{
    string[] nameMoney = Console.ReadLine().Split(";");
    foreach (var item in nameMoney)
    {
        string[] tockens = item.Split("=");
        string name = tockens[0];
        decimal money = decimal.Parse(tockens[1]);
        Person person = new Person(name, money);
        people.Add(person);
    }
    string[] productsCost = Console.ReadLine().Split(";");
    foreach (var item in productsCost)
    {
        string[] tockens = item.Split("=");

        Product product = new Product(tockens[0], decimal.Parse(tockens[1]));
        products.Add(product);
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
    return;
}


while (true)
{
    string[] orders = Console.ReadLine().Split(" ");
    if (orders[0] == "END")
    {
        break;
    }
    string name = orders[0];
    string productName = orders[1];
    Person person = people.FirstOrDefault(p => p.Name == name);
    Product product = products.FirstOrDefault(p => p.Name == productName);
    if (person != null && product != null)
    {
        Console.WriteLine(person.AddProduct(product));
    }
}
Console.WriteLine(string.Join(Environment.NewLine, people));