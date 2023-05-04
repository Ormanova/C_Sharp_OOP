using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Exceptions;

public class InsufficientFuelException : Exception
{
    public InsufficientFuelException(string message) : base(message)
    {

    }
}

