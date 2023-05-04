
using BirthdayCelebrations.Core;
using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.IO;

namespace BirthdayCelebrations;
public class StartUp
{
    public static void Main()
    {
        IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
        engine.Run();
    }
}