namespace Switch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            Console.WriteLine("Hello, pick a number between 1 and 7");
            var input = Console.ReadLine();


            switch (input)
            {
                case "1":
                    Console.WriteLine("You picked Monday!");
                    break;
                case "2":
                    Console.WriteLine("You picked Tuesday!");
                    break;
                case "3":
                    Console.WriteLine("You picked Wednesday!");
                    break;
                case "4":
                    Console.WriteLine("You picked Thursday!");
                    break;
                case "5":
                    Console.WriteLine("You picked Friday!");
                    break;
                case "6":
                    Console.WriteLine("You picked Saturday!");
                    break;
                case "7":
                    Console.WriteLine("You picked Sunday!");
                    break;
                default:
                    Console.WriteLine("Between 1 and 7, you are kind of slow, eh?");
                    break;
            }
        }
    }
}
