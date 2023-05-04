using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>(); 
            while (true)
            {
                
                string[] currentVehicle = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (currentVehicle.ToString() == "End")
                {
                    break;
                }
                string type = currentVehicle[0];
                if (type == "car")
                {
                    string model = currentVehicle[1];
                    string colour = currentVehicle[2];
                    int horsePower = int.Parse(currentVehicle[3]);
                    Car currentCar = new Car(type, model, colour, horsePower);
                    cars.Add(currentCar);
                }
                if (type == "truck")
                {
                    string model = currentVehicle[1];
                    string colour = currentVehicle[2];
                    int horsePower = int.Parse(currentVehicle[3]);
                    Truck currentTruck = new Truck(type, model, colour,horsePower);
                    trucks.Add(currentTruck);
                }
            }
            string modelOfVehicle = Console.ReadLine();
            if (cars.Any(c => cars.Model == modelOfVehicle )
            {

            }
        }
    }
    class Car
    {
        public Car(string type, string model, string colour, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Colour = colour;
            this.HorsePower = horsePower;

        }
        public string Type { get; set; }

        public string Model { get; set; }

        public string Colour { get; set; }

        public int HorsePower   { get; set; }
    }
    class Truck
    {
        public Truck(string type, string model, string colour, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Colour = colour;
            this.HorsePower = horsePower;

        }
    public string Type { get; set; }

    public string Model { get; set; }

    public string Colour { get; set; }

    public int HorsePower { get; set; }
}
}
