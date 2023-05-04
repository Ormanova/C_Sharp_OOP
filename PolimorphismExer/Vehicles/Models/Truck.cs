using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public class Truck : Vehicle
{
    private const double FuelConsumptionIncrement= 1.6;
   
   
    public Truck(double fuel, double fuelConsumption) : base(fuel, fuelConsumption, FuelConsumptionIncrement)
    {

    }

    // От абстрактния клас метода е virtual и тъй като имаме друга логика за камиона я имплементираме в override
    public override void Refuel(double liters)
    {
        base.Refuel(liters * 0.95);
    }

}

