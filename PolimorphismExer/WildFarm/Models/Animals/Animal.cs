using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }
        protected abstract double WeightIncrement { get; }
        public abstract IReadOnlyCollection<Type> PreferredFood { get; }


        public abstract string ProduceSound();
       
        
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, ";
        }

        public void Eat(IFood food)
        {
            if (!PreferredFood.Any(pf => food.GetType().Name == pf.Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            Weight += food.Quantity * WeightIncrement;
            FoodEaten += food.Quantity;
        }
    }
}
