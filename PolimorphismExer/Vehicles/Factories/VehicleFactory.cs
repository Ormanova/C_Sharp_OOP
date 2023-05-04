

namespace Vehicles.Factories;

using Exceptions;
using Interfaces;
using Models;
using Models.Interfaces;

//this should not be static
public class VehicleFactory : IVehicleFactory
{
    //празен конструктур
    public VehicleFactory()
    {

    }
    // създаваме си каквото и да е превозно средство
    public IVehicle CreateVehicle(string type, double fuel, double fuelConsumption)
    {
        //TODO: Try to rewrite the factory without conditions for different vehicle types
        //Use reflection
        IVehicle vehicle;
        if (type == "Car")
        {
            vehicle = new Car(fuel, fuelConsumption);
        }
        else if (type == "Truck")
        {
            vehicle = new Truck(fuel, fuelConsumption);
        }
        else
        {
            throw new InvalidVehicleTypeException();
        }
        return vehicle;
    }
}

