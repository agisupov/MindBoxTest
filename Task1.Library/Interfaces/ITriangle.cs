namespace Task1.Library.Interfaces
{
    public interface ITriangle : IFigure
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }
        bool IsRightTriangle { get; }
    }
}
