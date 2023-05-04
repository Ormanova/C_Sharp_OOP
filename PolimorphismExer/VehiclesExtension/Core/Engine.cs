


namespace VehiclesExtension.Core
{
    using Interfaces;
    using IO.Interfaces;
    using System;
    using VehiclesExtension.Factories;
    using VehiclesExtension.Factories.Interfaces;
    using VehiclesExtension.Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;
        //В конструктура приемаме някъде отвън IReader IWriter
        public Engine(IReader reader,IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;

            vehicles = new List<IVehicle>(); // allow us to add other vehicles in the future
        }

        public void Run()
        {
            vehicles.Add(CreateVehicle()); //add Car
            vehicles.Add(CreateVehicle()); // add Truck
            vehicles.Add(CreateVehicle());

            int n = int.Parse(reader.ReadLne());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    ProcessComand();
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch(Exception)
                {
                    throw;
                }
            }
            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }

        private void ProcessComand()
        {
            string[] tockens = reader.ReadLne().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            string comand = tockens[0];
            string vehicleType = tockens[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);
            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }
            if (comand == "Drive")
            {
                double distance = double.Parse(tockens[2]);
                writer.WriteLine(vehicle.Drive(distance));
            }
            else if (comand == "DriveEmpty")
            {
                double distance = double.Parse(tockens[2]);
                writer.WriteLine(vehicle.Drive(distance, false));
            }
            else if(comand == "Refuel")
            {
                double liters = double.Parse(tockens[2]);
                vehicle.Refuel(liters);
            }
        }

        private IVehicle CreateVehicle()
        {
            string[] input = reader.ReadLne().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //прочита параметрите от входа и ги подава на Factories да създаде и добави превозносто средство към колкекцията
            return vehicleFactory.Create(input[0], double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
        }
    }
}
