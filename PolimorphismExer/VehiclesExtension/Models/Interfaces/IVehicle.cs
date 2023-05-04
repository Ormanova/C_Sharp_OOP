
namespace VehiclesExtension.Models.Interfaces
{
    public interface IVehicle
    {

        //Car and truck both have fuel quantity, fuel consumption in liters per km, and can be driven a given distance and refueled with a given amount of fuel.
        public double FuelQuantity { get;}
        public double FuelConsumption { get;}

        public double TankCapacity { get;}


        //метода е стринг защото връща съобщения
        public string Drive(double distance, bool isIncreased = true);


        // метода е воид защото нищо не връща, само променя стойността на горивото с дадените литри
        public void Refuel(double liters);
        
    }
}
