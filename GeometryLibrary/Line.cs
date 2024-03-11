namespace GeometryLibrary;

public class Line : Figure
{
    public Point FromPoint { get; set; }

    public Point ToPoint { get; set; }

    public Line(Point fromPoint, Point toPoint)
    {
        FromPoint = fromPoint;
        ToPoint = toPoint;
    }

    public override double GetSquare()
    {
        return 0;
    }

    public override Point GetCenterPoint()
    {
        return new Point((ToPoint.X - FromPoint.X) / 2, (ToPoint.Y - FromPoint.Y) / 2);
    }

    public override Rectangle GetBoxRectangle()
    {
        return new Rectangle(
            new Point(Math.Min(FromPoint.X, ToPoint.X), Math.Min(FromPoint.Y, ToPoint.Y)),
            new Point(Math.Max(FromPoint.X, ToPoint.X), Math.Min(FromPoint.Y, ToPoint.Y)),
            new Point(Math.Min(FromPoint.X, ToPoint.X), Math.Max(FromPoint.Y, ToPoint.Y)),
            new Point(Math.Max(FromPoint.X, ToPoint.X), Math.Max(FromPoint.Y, ToPoint.Y))
        );
    }

    public override string ToString()
    {
        return $"Линия. Точка начала - {FromPoint}. " +
               $"Точка конца - {ToPoint}. ";
    }
}