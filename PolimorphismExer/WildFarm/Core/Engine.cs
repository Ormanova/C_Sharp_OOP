using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Interface;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        private readonly ICollection<IAnimal> animals;

        public Engine(
            IReader reader,
            IWriter writer,
            IAnimalFactory animalFactory,
            IFoodFactory foodFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
            animals = new List<IAnimal>();
        }
        public void Run()
        {
            string comand;
            while ((comand = reader.ReadLine()) != "End")
            {
                IAnimal animal = null;

                try
                {
                    animal = CreateAnimal(comand);
                    IFood food = CreateFood();
                    writer.WriteLine(animal.ProduceSound());
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message); 
                }
                catch (Exception)
                {
                    throw;
                }
                animals.Add(animal);
            }
            foreach (IAnimal animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }

        private IFood CreateFood()
        {
            string[] foodTockens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string foodType = foodTockens[0];
            int quantity = int.Parse(foodTockens[1]);
            IFood food = foodFactory.CreateFood(foodType, quantity);
            return food;
        }

        private IAnimal CreateAnimal(string comand)
        {
            string[] animalArgs = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IAnimal animal = animalFactory.CreateAnimal(animalArgs);
            return animal;
        }
    }
}
