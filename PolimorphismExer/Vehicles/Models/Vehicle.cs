

namespace Vehicles.Models;

using Exceptions;
using Interfaces;
public abstract class Vehicle : IVehicle
{
    protected Vehicle(double fuel, double fuelConsumption, double fuelConsumptionIncrement)
    {
        this.Fuel = fuel;
        this.FuelConsumption = fuelConsumption + fuelConsumptionIncrement;
    }
    public double Fuel { get; private set; }

    public double FuelConsumption { get; private set; }

    public string Drive(double distance)
    {
        double neededFuel = distance * this.FuelConsumption;
        if (neededFuel > this.Fuel)
        {
            throw new InsufficientFuelException(string.Format(ExceptionMessages.InsufficientFuelExceptionMessage, this.GetType().Name));
            // GetType - DataType ;  .Name -> Car/Truck
        }
        this.Fuel -= neededFuel;
        return $"{this.GetType().Name} travelled {distance} km";
    }
    // Truck has different refuel logic
    // we make the method virtual and truck will override it (Run-time polymorphism)
    public virtual void Refuel(double liters)
    {
        Fuel += liters;
    }
    public  override string ToString()
    {
        return $"{this.GetType().Name}: {this.Fuel:f2}";
            //this -> current instance
            //GetType() -> DataType
            //Name -> string
    }

}

