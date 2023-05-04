using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension.Factories.Interfaces
{
    using VehiclesExtension.Models.Interfaces;
    public interface IVehicleFactory
    {
        IVehicle Create(string type, double fuel, double consumption, double tankCapacity);
    }
}
