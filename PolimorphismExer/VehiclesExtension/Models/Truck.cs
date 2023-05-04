

namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double increasedConsumption = 1.6;

        public Truck(double fuelQuantity, double consumption, double tankCapacity) : base(fuelQuantity, consumption, tankCapacity, increasedConsumption)
        {
        }
         public override void Refuel(double liters)
        {
            if (liters + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            base.Refuel(liters * 0.95);
        }
    }
}
