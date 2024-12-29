namespace Shapes
{
    internal class ShapeManager
    {
        public List<Shape> _shapes { get; }
        public ShapeManager()
        {
            _shapes =
            [
                new Circle("CircleOne", "Red",15, 1),
                new Circle("CircleTwo", "Blue",25, 2),
                new Rectangle("RectangleOne", "Blue", 15.00,15.00, 3),
                new Rectangle("RectangleTwo", "Black", 25.00,15.00, 4),
                new Triangle("TriangleOne","Grey", 15.00,20.00, 5 ),
                new Triangle("TriangleTwo","Black", 25.00,22.00, 6 ),
            ];
        }
        public void ShowList()
        {
            foreach (var s in _shapes)
            {
                Console.WriteLine(s.Id + "." + "Shape:" + s.Name + "Color:" + s.Color);
            }

            Console.WriteLine("Enter number to find out area");
            var input = Convert.ToInt32(Console.ReadLine());
            var chosenShape = _shapes.Find(s => s.Id == input);
            Console.WriteLine(chosenShape != null
                ? $"\nArea of {chosenShape.Name} is {chosenShape.Area}"
                : "No shape found.");
        }

        public double CalculateAllShapesArea()
        {
            var sum = 0.00;
            foreach (var s in _shapes)
            {
                sum += s.Area;
            }
            return sum;
        }

        public void FilterByColor()
        {
            var search = EnterSearchTerm();
            var results = _shapes.Where(shape => shape.Color.ToLower().Equals(search)).ToList();
            if (results.Count > 0)
            {
                Console.WriteLine("Here is your color search results");
                foreach (var s in results)
                {
                    Console.WriteLine($"{s.Id}.{s.Name} - Color:{s.Color}");
                }
            }
            else
            {
                Console.WriteLine("No matches found, try again.");
            }

        }
        public string EnterSearchTerm()
        {
            Console.WriteLine("Enter search term");
            var input = Console.ReadLine()?.ToLower();
            return input;
        }
        public void SortByArea(char input)
        {
            if (input != '1' && input != '2')
            {
                Console.WriteLine("Invalid input, input 1 or 2.");
                return;
            }
            var sortedShapes = input == '1'
                ? _shapes.OrderByDescending(s => s.Area).ToList()
                : _shapes.OrderBy(s => s.Area).ToList();

            foreach (var s in sortedShapes)
            {
                Console.WriteLine($"{s.Name} - Area:{s.Area}");
            }

        }

    }
}
