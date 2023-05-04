

namespace VehiclesExtension.Exceptions
{
    using System;
    public class InsufficientFuelException : Exception
    {
        //този конкретен клас , наследява клас Exception, за да стане ексепшън
        //Може да се направи дефолтен конструктор и такъв , който приема съобщение
        //В този случай ще трябва да идва отвън съобщението, защото е следното "Car/Truck travelled {distance} km", където трябва да се избира между колла или камион.
        public InsufficientFuelException(string message) : base(message)
        {

        }
    }
}
