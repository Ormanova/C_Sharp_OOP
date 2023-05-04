


namespace VehiclesExtension.Models
{
    using Exceptions;
    using Interfaces;


    // правим го абстрактен, защото няма да се инстанцира, той е модел за други 2 класа - кола и камион
    //имплементира IVehicle

    public abstract class Vehicle : IVehicle
    {
        private double increasedConsumption;
        private double fuelQuantity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double increasedConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
           this.increasedConsumption = increasedConsumption;
        }
        public double FuelQuantity {
            get => fuelQuantity;
            private set
            {
                if (TankCapacity < value)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }

        public string Drive(double distance, bool isIncreased = true)
        {
           double consumption = isIncreased 
                ? FuelConsumption + increasedConsumption
                : FuelConsumption;
            if (FuelQuantity < distance * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            FuelQuantity -= distance * consumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (liters + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            FuelQuantity += liters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}

