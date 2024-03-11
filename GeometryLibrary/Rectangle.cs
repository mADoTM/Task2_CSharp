namespace GeometryLibrary;

public class Rectangle : Figure
{
    public Point UpLeftPoint { get; set; }
    public Point UpRightPoint { get; set; }
    public Point DownLeftPoint { get; set; }
    public Point DownRightPoint { get; set; }

    public Rectangle(Point point)
    {
        UpLeftPoint = point;
        UpRightPoint = point;
        DownLeftPoint = point;
        DownRightPoint = point;
    }

    public Rectangle(Point upLeftPoint, Point upRightPoint, Point downLeftPoint, Point downRightPoint)
    {
        UpLeftPoint = upLeftPoint;
        UpRightPoint = upRightPoint;
        DownLeftPoint = downLeftPoint;
        DownRightPoint = downRightPoint;
    }

    public override double GetSquare()
    {
        return Math.Abs(UpLeftPoint.X - UpRightPoint.X) * Math.Abs(UpLeftPoint.Y - DownLeftPoint.Y);
    }

    public override Point GetCenterPoint()
    {
        return new Line(DownLeftPoint, UpRightPoint).GetCenterPoint();
    }

    public override Rectangle GetBoxRectangle()
    {
        return this;
    }

    public override string ToString()
    {
        return $"Прямоугольник. Левая верхняя точка - {UpLeftPoint}. " +
               $"Правая верхняя точка - {UpRightPoint}. " +
               $"Левая нижняя точка- {DownLeftPoint}. " +
               $"Правая нижняя точка - {DownRightPoint}";
    }
}