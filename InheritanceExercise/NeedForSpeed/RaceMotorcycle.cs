

namespace NeedForSpeed;

    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumptionMotor = 8;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption => DefaultFuelConsumptionMotor;
    }

