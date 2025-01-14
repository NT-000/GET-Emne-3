namespace two_numbers_true
{
    internal class Program
    {
        Random num = new Random();
        int randomNumber;
        int randomNumber2;
        bool isEqual;
        int sum;

        public Program()
        {
            randomNumber = num.Next(1, 30);
            randomNumber2 = num.Next(1, 30);
            sum = randomNumber + randomNumber2;
        }

        public void Run()
        {
            Console.WriteLine($"Random num 1: {randomNumber}");
            Console.WriteLine($"Random num 2: {randomNumber2}");
            Console.WriteLine($"Both: {sum}");
            if (randomNumber == randomNumber2)
            {
                isEqual = true;
                Console.WriteLine("The numbers match");
            }
            else
            {
                isEqual = false;
                Console.WriteLine($"Don't match");
            }

            if (sum == 30)
            {
                isEqual = true;
                Console.WriteLine("Sum is 30!");
            }
            else
            {
                isEqual = false;
                Console.WriteLine($"Sum is: {sum}");
            }

            if (isEqual)
            {
                Console.WriteLine($"{randomNumber} and {randomNumber2} multiplied is: {Calculate()}");
            }
        }

        public int Calculate()
        {
            return randomNumber * randomNumber2;
        }

        static void Main(string[] args)
        {
            do
            {
                var launch = new Program();
                launch.Run();
                Console.WriteLine("Do you want to try again? yes or no.");
                string input = Console.ReadLine();
                if (input != "yes")
                {
                    Console.WriteLine("Shutting down...");
                    break;
                }
            } while (true);
        }
    }
}