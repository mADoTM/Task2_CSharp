using System.Text;
using System.Windows;
using Figure = GeometryLibrary.Figure;
using Point = GeometryLibrary.Point;
using Line = GeometryLibrary.Line;
using Ellipse = GeometryLibrary.Ellipse;
using Rectangle = GeometryLibrary.Rectangle;

namespace Task3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private IList<Figure> _figures = new List<Figure>();
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowFiguresListButtonClick(object sender, RoutedEventArgs e)
    {
        var builder = new StringBuilder();

        builder.AppendLine("Фигуры:");

        builder.AppendLine("~~~~~~~~~~~~");
        foreach (var figure in _figures)
        {
            builder.AppendLine(figure.ToString());
            builder.AppendLine($"Центр фигуры - {figure.GetCenterPoint()}");
            builder.AppendLine($"Площадь фигуры - {figure.GetSquare()}");
            builder.AppendLine($"Очерчивающий прямоугольник - {figure.GetBoxRectangle()}");
            builder.AppendLine("~~~~~~~~~~~~");
        }

        MessageBox.Show(builder.ToString());
    }

    private void CreateLineOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _figures.Add(ParseLineFromString(LineCoordBox.Text));
        }
        catch (Exception exc)
        {
            MessageBox.Show("Вы ввели некорректные данные для создания линии. Попробуйте снова");
        }
    }

    private void CreatePointOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _figures.Add(ParsePointFromString(PointCoordBox.Text));
        }
        catch (Exception exc)
        {
            MessageBox.Show("Вы ввели некорректные данные для создания точки. Попробуйте снова");
        }
    }

    private void CreateEllipseClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _figures.Add(ParseEllipseFromString(EllipseCoordbox.Text));
        }
        catch (Exception exc)
        {
            MessageBox.Show("Вы ввели некорректные данные для создания окружности. Попробуйте снова");
        }
    }

    private void CreateRectangleBox(object sender, RoutedEventArgs e)
    {
        try
        {
            _figures.Add(ParseRectangleFromString(RectangleCoordBox.Text));
        }
        catch (Exception exc)
        {
            MessageBox.Show("Вы ввели некорректные данные для создания прямоугольника. Попробуйте снова");
        }
    }
    
    private Rectangle ParseRectangleFromString(string source)
    {
        var coords = source.Split(new[]{ Environment.NewLine }, StringSplitOptions.None);
        var point1 = ParsePointFromString(coords[0]);
        var point2 = ParsePointFromString(coords[1]);
        var point3 = ParsePointFromString(coords[2]);
        var point4 = ParsePointFromString(coords[3]);

        return new Rectangle(point1, point2, point3, point4);
    }


    private Ellipse ParseEllipseFromString(string source)
    {
        var coords = source.Split(new[]{ Environment.NewLine }, StringSplitOptions.None);
        var pointFrom = ParsePointFromString(coords[0]);
        var radius = Convert.ToDouble(coords[1]);

        return new Ellipse(pointFrom, radius);
    }

    private Line ParseLineFromString(string source)
    {
        var coords = source.Split(new[]{ Environment.NewLine }, StringSplitOptions.None);
        Console.WriteLine(source);
        Console.WriteLine(coords[0] + " " + coords[1]);
        var pointFrom = ParsePointFromString(coords[0]);
        var pointTo = ParsePointFromString(coords[1]);

        return new Line(pointFrom, pointTo);
    }

    private Point ParsePointFromString(string source)
    {
        var coord = source.Split(";");

        double x = Convert.ToDouble(coord[0]);
        double y = Convert.ToDouble(coord[1]);

        return new Point(x, y);
    }
}