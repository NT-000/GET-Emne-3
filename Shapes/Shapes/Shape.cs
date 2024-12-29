namespace Shapes
{
    internal abstract class Shape
    {
        public string Name { get; protected set; }
        public string Color { get; protected set; }
        public int Id { get; protected set; }

        public double Area { get; set; }

        public Shape(string name, string color, int id)
        {
            Name = name;
            Color = color;
            Id = id;
            Area = 0;
        }
        public abstract double CalculateArea();


    }
}
