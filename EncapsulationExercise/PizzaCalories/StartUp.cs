using System; 
using System.Collections.Generic;
using System.Linq;
using PizzaCalories.Models;

try
{
    string[] pizzaInput = Console.ReadLine().Split(" ");
    string pizzaName = pizzaInput[1];
    string[] doughInput = Console.ReadLine().Split(" ");

    Dough dough = new(doughInput[1].ToLower(), doughInput[2].ToLower(), double.Parse(doughInput[3]));
    Pizza pizza = new Pizza(pizzaName, dough);
    while (true)
    {
        string toppingsInput = Console.ReadLine();
        if (toppingsInput == "END")
        {
            break;
        }
        string[] toppingsTockens = toppingsInput.Split();
        Topping topping = new (toppingsTockens[1], double.Parse(toppingsTockens[2]));
        pizza.AddTopping(topping);
    }
    Console.WriteLine(pizza);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

