using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorderControl.IO.Interfaces;

namespace BorderControl.IO;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string text)
    {
        Console.WriteLine(text);
    }
}

