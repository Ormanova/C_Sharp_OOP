using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension.Factories
{
    using System;
    using Models;
    using Models.Interfaces;
    using Interfaces;
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string type, double fuel, double consumption, double tankCapacity)
        {
            switch (type)
            {
                case "Car":
                    return  new Car(fuel, consumption, tankCapacity);
                    
                case "Truck":
                    return  new Truck(fuel, consumption, tankCapacity);
                    
                case "Bus":
                    return new Bus(fuel,consumption,tankCapacity);
                   
                default:
                    throw new ArgumentException("Invalid vehicle type");
              
            }
        }

    }
}
