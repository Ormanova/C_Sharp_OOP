using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public class Car : Vehicle
{
    private const double FuelConsumptionIncrement = 0.9;
   

    public Car(double fuel, double fuelConsumption) : base(fuel, fuelConsumption, FuelConsumptionIncrement)
    {

    }
   
}

