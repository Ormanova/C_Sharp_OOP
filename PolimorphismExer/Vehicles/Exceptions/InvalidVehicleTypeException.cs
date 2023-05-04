using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Exceptions
{
    public class InvalidVehicleTypeException : Exception
    {
        private const string DefaultMesage = "Vehicle type not supported";

        //static polymorphism (Compile time)
        public InvalidVehicleTypeException() : base(DefaultMesage)
        {

        }
        public InvalidVehicleTypeException(string message) : base(message)
        {

        }
    }
}
