using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorderControl.IO.Interfaces;

namespace BorderControl.IO;

public class ConsoleReader : IReader
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}

