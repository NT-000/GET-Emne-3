namespace ClickerGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clicker = new ClickerGame();
            var commandSet = new CommandSet();
            while (true)
            {

                DisplayMenu(clicker, commandSet);
            }
        }

        private static void DisplayMenu(ClickerGame clicker, CommandSet commandSet)
        {
            Console.Clear();
            ChangeColors();
            Console.ResetColor();
            Console.WriteLine($"Poengsum: {clicker.Sum}\n");
            Console.WriteLine("SPACE = 1 poeng: Pluss ett poeng per klikk");
            Console.WriteLine("K = 10 poeng: øker poeng per klikk.");
            Console.WriteLine("S = 100 poeng : Super-oppgradering øker med ett poeng per klikk for den vanlige oppgraderingen.");
            Console.WriteLine("X = Avslutt\n");
            Console.WriteLine("Velg din tast:");
            var key = Console.ReadKey().KeyChar;
            commandSet.RunCommand(key, clicker);
        }

        static void ChangeColors()
        {
            Random random = new Random();

            string text = "!!! CLICKER SPILLET !!!";
            ConsoleColor[] colors = 
            [
                ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue,
                ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Magenta,
                ConsoleColor.White, ConsoleColor.DarkYellow, ConsoleColor.DarkBlue
            ];

            int num = random.Next(colors.Length);
            foreach (char c in text)
            {
                Console.ForegroundColor = colors[num];
                Console.Write(c);
                Thread.Sleep(30);
                num = (num + 1) % colors.Length;
            }
            Console.WriteLine();
            Console.ResetColor();
        }

    }
}