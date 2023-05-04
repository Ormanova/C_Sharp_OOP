

namespace VehiclesExtension.IO
{
    using System;
    using Interfaces;
    public class ConsoleReader : IReader
    {
        public string ReadLne()
        {
           return Console.ReadLine();
        }
    }
}
