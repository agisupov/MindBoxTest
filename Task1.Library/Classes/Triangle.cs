namespace Task1.Library.Classes
{
    public class Triangle : IFigure
    {
        private double eps = Constants.CalculationAccuracy;

        private readonly Lazy<bool> _isRightTriangle;

        public Triangle(double edgeA, double edgeB, double edgeC)
        {
            if (edgeA < eps)
                throw new ArgumentException("Ошибка! Неверно указана сторона", nameof(edgeA));

            if (edgeB < eps)
                throw new ArgumentException("Ошибка! Неверно указана сторона", nameof(edgeB));

            if (edgeC < eps)
                throw new ArgumentException("Ошибка! Неверно указана сторона", nameof(edgeC));

            var maxEdge = Math.Max(edgeA, Math.Max(edgeB, edgeC));
            var perimeter = edgeA + edgeB + edgeC;
            if ((perimeter - maxEdge) - maxEdge < Constants.CalculationAccuracy)
                throw new ArgumentException("Ошибка! Наибольшая сторона треугольника должна быть меньше суммы других сторон");

            EdgeA = edgeA;
            EdgeB = edgeB;
            EdgeC = edgeC;

            _isRightTriangle = new Lazy<bool>(GetIsRightTriangle);
        }

        public double EdgeA { get; }
        public double EdgeB { get; }
        public double EdgeC { get; }
        public bool IsRightTriangle => _isRightTriangle.Value;

        private bool GetIsRightTriangle()
        {
            double maxEdge = EdgeA, b = EdgeB, c = EdgeC;
            if (b - maxEdge > Constants.CalculationAccuracy)
                Swap(ref maxEdge, ref b);

            if (c - maxEdge > Constants.CalculationAccuracy)
                Swap(ref maxEdge, ref c);

            return Math.Abs(Math.Pow(maxEdge, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) < Constants.CalculationAccuracy;
        }

        public double GetSquare()
        {
            var halfP = (EdgeA + EdgeB + EdgeC) / 2d;
            var square = Math.Sqrt(
                halfP
                * (halfP - EdgeA)
                * (halfP - EdgeB)
                * (halfP - EdgeC)
            );

            return square;
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
