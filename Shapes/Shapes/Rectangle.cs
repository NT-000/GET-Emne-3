namespace Shapes
{
    internal class Rectangle : Shape
    {
        double Length { get; set; }
        double Width { get; set; }
        public Rectangle(string name, string color, double length, double width, int id) : base(name, color, id)
        {
            Name = name;
            Color = color;
            Width = width;
            Length = length;
            Id = id;
            Area = CalculateArea();
        }
        public override double CalculateArea()
        {
            return Width * Length;
        }
    }
}
