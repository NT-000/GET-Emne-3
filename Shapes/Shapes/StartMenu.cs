namespace Shapes
{
    internal class StartMenu
    {

        public StartMenu(ShapeManager shapeManager)
        {

            Menu(shapeManager);
        }

        public void Menu(ShapeManager shapeManager)
        {
            Console.WriteLine("1.Show list");
            Console.WriteLine("2.Calculate area in all the shapes in the list");
            Console.WriteLine("3.Filter by color");
            Console.WriteLine("4.Sort by area");
            while (true)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        shapeManager.ShowList();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine($" {shapeManager.CalculateAllShapesArea()} is the total area of all shapes in the list.");
                        break;
                    case '3':
                        Console.Clear();
                        shapeManager.FilterByColor();
                        break;
                    case '4':
                        Console.Clear();
                        SortMenu(shapeManager);
                        break;
                }
            }
        }

        public void SortMenu(ShapeManager shapeManager)
        {   
            var isRunning = true;
            while (isRunning)
            {
                var input = Console.ReadKey(true).KeyChar;
                Console.WriteLine("1.Sort shapes area high-low");
                Console.WriteLine("2.Sort shapes low-high");
                Console.WriteLine("3.Go back");
                switch (input)
                {
                    case '1':
                    case '2':
                        Console.Clear();
                        shapeManager.SortByArea(input);
                        break;
                    case '3':
                        isRunning = false;
                        break;
                }
            }
        }




    }
}
