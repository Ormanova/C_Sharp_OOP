using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        //A Pizza should have a name, some toppings, and dough.
        private string name;
        private readonly List<Topping> toppings;
        

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        //a Pizza should have public getters for its name, the number of toppings, and the total calories.
        public string Name 
        {
            get => name;
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException(ExceptionMessages.PizzaNameExceptionMessage);
                }
                name = value;
            }
        }
        public Dough Dough
        {
            get;
            private set;
            
        }
        public double TotalCalories
        {
            get
            {
                //The total calories are calculated by summing the calories of all the ingredients a Pizza has. 
                return Dough.DoughCalories + toppings.Sum(t => t.ToppingCalories);
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }
    }
}
