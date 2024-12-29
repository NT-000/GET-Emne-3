namespace Shapes
{
    internal class Circle : Shape
    {
        double Radius { get; }
        public Circle(string name, string color, int radius, int id) : base(name, color, id)
        {
            Name = name;
            Color = color;
            Radius = radius;
            Id = id;
            Area = CalculateArea();

        }
        public override double CalculateArea()
        {
            return 3.14 * Radius * Radius;
        }
    }
}
