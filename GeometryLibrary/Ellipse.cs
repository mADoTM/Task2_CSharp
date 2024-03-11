namespace GeometryLibrary;

public class Ellipse : Figure
{
    public Point Center { get; set; }
    
    public double Radius { get; set; }

    public Ellipse(Point center, double radius)
    {
        if (radius < 0)
            throw new ArgumentException("Радиус не может быть отрицательным");
        Center = center;
        Radius = radius;
    }

    public override double GetSquare()
    {
        return 2 * Math.PI * Radius * Radius;
    }

    public override Point GetCenterPoint()
    {
        return Center;
    }

    public override Rectangle GetBoxRectangle()
    {
        return new Rectangle(new Point(Center.X - Radius, Center.Y - Radius),
            new Point(Center.X - Radius, Center.Y + Radius),
            new Point(Center.X + Radius, Center.Y - Radius),
            new Point(Center.X + Radius, Center.Y + Radius));
    }
    
    public override string ToString()
    {
        return $"Окружность. Координата центра - {Center}. Радиус - {Radius}";
    }
}