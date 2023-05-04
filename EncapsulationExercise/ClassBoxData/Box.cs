

namespace ClassBoxData;

public class Box
{
    private double length;
    private double width;
    private double height;
    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }
    public double Length
    {
        get
        {
            return length;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
            }
            length = value;
        }
    }
    public double Width
    {
        get
        {
            return width;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
            }
            width = value;
        }
    }
    public double Height
    {
        get
        {
            return height;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
            }
            height = value;
        }
    }

    public void SurfaceArea()
    {
        double surfaceArea = 2 * Length * Width + 2 * Length * Height + 2 * Height * Width;
        Console.WriteLine($"Surface Area - {surfaceArea:f2}");
    }
    public void LateralSurfaceArea()
    {
        double lateralSurfaceArea = 2 * Height * (Length + Width);
        Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
    }

    public void Volume()
    {
       double volume = Length* Width *Height;
        Console.WriteLine($"Volume - {volume:f2}");
    }
}

