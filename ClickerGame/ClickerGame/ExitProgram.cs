namespace ClickerGame
{
    internal class ExitProgram : ICommand
    {
        public char Key { get; set; } = 'x';
        public void Run(ClickerGame clicker)
        {
            Console.WriteLine("Exiting the program...");
            Console.WriteLine($"Your score:");
            Environment.Exit(0);
        }
    }
}
