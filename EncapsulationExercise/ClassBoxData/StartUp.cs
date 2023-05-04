﻿
namespace ClassBoxData;

public class StartUp
{

    public static void Main()
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());


        try
        {
            Box box = new Box(length, width, height);
            box.SurfaceArea();
            box.LateralSurfaceArea();
            box.Volume();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}

