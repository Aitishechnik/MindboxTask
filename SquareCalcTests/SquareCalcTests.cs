using MindboxTask;

[TestClass]
public class SquareCalcTests
{
    private StringWriter stringWriter;

    [TestInitialize]
    public void Setup()
    {
        stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
    }

    [TestCleanup]
    public void Cleanup()
    {
        Console.SetOut(Console.Out);
        stringWriter.Dispose();
    }

    [TestMethod]
    public void TestCalculateCircleSquare()
    {
        var calc = new SquareCalc();
        double radius = 5;

        calc.AddFigure(radius);

        string output = stringWriter.ToString();
        Assert.IsTrue(output.Contains($"Площадь круга с радиусом {radius} составляет: {Math.PI * Math.Pow(radius, 2)}"));
    }

    [TestMethod]
    public void TestCalculateTriangleSquare()
    {
        var calc = new SquareCalc();
        double a = 3, b = 4, c = 5;

        calc.AddFigure(a, b, c);

        string output = stringWriter.ToString();
        Assert.IsTrue(output.Contains("Площадь теугольника: "));
    }

    [TestMethod]
    public void TestCalculateInvalidTriangle()
    {
        var calc = new SquareCalc();
        double a = 1, b = 1, c = 3; 

        Assert.ThrowsException<ArgumentException>(() => calc.AddFigure(a, b, c));
    }

    [TestMethod]
    public void TestRightTriangle()
    {
        var calc = new SquareCalc();
        double a = 3, b = 4, c = 5;

        calc.AddFigure(a, b, c);

        string output = stringWriter.ToString();
        Assert.IsTrue(output.Contains("Треугольник явлется прямоугольным"));
    }
}