namespace Shapes
{
    internal class Triangle : Shape
    {
        double BaseLine { get; }
        double Height { get; }
        public Triangle(string name, string color, double baseLine, double height, int id) : base(name, color, id)
        {
            Name = name;
            Color = color;
            BaseLine = baseLine;
            Height = height;
            Id = id;
            Area = CalculateArea();
        }
        public override double CalculateArea()
        {
            return BaseLine / 2 * Height;
        }
    }
}
