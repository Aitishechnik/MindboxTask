namespace MindboxTask
{
    public class SquareCalc
    {
        public void AddFigure(double radius)
        {
            CalculateCicrlceSqare(radius);
        }

        public void AddFigure(double a, double b, double c, params double[] sides)
        {
            double[] allSides = new double[3 + sides.Length];
            allSides[0] = a;
            allSides[1] = b;
            allSides[2] = c;
            for (int i = 3; i < allSides.Length; i++)
                allSides[i] = sides[i-3];
            CalculateFigureSquare(allSides, allSides.Length == 3);
            if (allSides.Length == 3)
                CheckIfRightTriangle(allSides[0], allSides[1], allSides[2]);
        }

        private void CalculateFigureSquare(double[] sides, bool isTriangle)
        {
            double[] temp = new double[sides.Length];
            double p = sides.Sum() / 2;
            double result = p;
            for (int i = 0; i < sides.Length; i++)
            {
                CheckSideLengthValidity(p - sides[i] > 0, isTriangle);
                result *= p - sides[i];
            }            
            result = Math.Sqrt(result);

            Console.WriteLine("Площадь " + (isTriangle?"теугольника: ":"многоугольника: ") + result);
        }

        private void CalculateCicrlceSqare(double radius)
        {
            Console.WriteLine($"Площадь круга с радиусом {radius} составляет: " + (Math.PI * Math.Pow(radius, 2)));
        }

        private void CheckSideLengthValidity(bool isValid, bool isTriangle)
        {
            if(!isValid)
            {
                throw new ArgumentException(isTriangle? "Длины сторон не могут образовать треугольник." : 
                    "Длины сторон не могут образовать многоугольник.");
            }
        }

        private void CheckIfRightTriangle(double a, double b, double c)
        {
            double hypotenuse = a;
            double leg1 = b;
            double leg2 = c;

            if(b > a && b > c)
            {
                hypotenuse = b;
                leg1 = c;
                leg2 = a;
            }
            else if (c > a && c > b)
            {
                hypotenuse = c;
                leg1 = a;
                leg2 = b;
            }

            string result = Math.Pow(hypotenuse, 2) == Math.Pow(leg1, 2) + Math.Pow(leg2, 2) ? "Треугольник явлется прямоугольным" :
                "Треугольник не явлется прямоугольным";
            Console.WriteLine(result);
        }
    }
}
