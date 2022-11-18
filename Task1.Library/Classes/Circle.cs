namespace Task1.Library.Classes
{
    public class Circle : IFigure
    {
        public const double MinRadius = 1e-9;

        public Circle(double radius)
        {
            if (radius - MinRadius < Constants.CalculationAccuracy)
                throw new ArgumentException("Ошибка! Неверно указан радиус круга", nameof(radius));
            Radius = radius;
        }

        public double Radius { get; }

        public double GetSquare()
        {
            return Math.PI * Math.Pow(Radius, 2d);
        }
    }
}
