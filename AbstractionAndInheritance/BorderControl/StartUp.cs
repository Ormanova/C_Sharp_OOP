using BorderControl.Core.Interfaces;
using BorderControl.Core;
using BorderControl.Models.Interfaces;
using BorderControl.IO;


namespace BorderControl;

public class StartUp
{
    public static void Main()
    {
        IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
        engine.Run();
    }
}