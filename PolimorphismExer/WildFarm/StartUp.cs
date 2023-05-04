

using WildFarm.Core;
using WildFarm.Core.Interface;
using WildFarm.Factories;
using WildFarm.Factories.Interfaces;
using WildFarm.IO;
using WildFarm.IO.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();

IAnimalFactory animalFActory = new AnimalFactory();
IFoodFactory foodFactory = new FoodFactory();

IEngine engine = new Engine(reader, writer, animalFActory, foodFactory);
engine.Run();
