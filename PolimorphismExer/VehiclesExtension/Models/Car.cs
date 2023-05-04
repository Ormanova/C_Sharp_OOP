

namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        //генерирания конструктор е public Car(double fuel, double consumption, double fuelConsumptionIncrement) : base(fuel, consumption, fuelConsumptionIncrement), но премахваме от текущия конструктур fuelConsumptionIncrement защото той не идва отвън. Задаваме го като константа в този клас и го сетваме чрез конструктура като го задаваме на базовия конструктур

        private const double increasedConsumption = 0.9;

        public Car(double fuelQuantity, double consumption, double tankCapacity) : base(fuelQuantity, consumption, tankCapacity, increasedConsumption)
        {
        }
    }
}
