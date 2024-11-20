namespace Krokodillespillet
{
    internal class Program
    {
        static int counter = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Hvilket tall er størst?");
            Run();
        }

        static void Run()
        {
            Random numRandom = new Random();
            int randNum = numRandom.Next(1, 11);
            int randNum2 = numRandom.Next(1, 11);
            

            Console.WriteLine($"Which is the biggest number?:{randNum}_{randNum2}");

            var input = Console.ReadLine();

            if (input is "<" or "=" or ">")
            {
                if (randNum > randNum2 && input == ">" ||
                    randNum < randNum2 && input == "<" ||
                    randNum == randNum2 && input == "=")
                {
                    counter++;
                    Console.WriteLine($"{randNum} {input} {randNum2} is correct");
                    Console.WriteLine($"Score:{counter}");

                }
            }

            if (input != "<" || input != "=" || input != ">")
            {

            }
            if (randNum > randNum2 && input != ">" ||
                randNum < randNum2 && input != "<" ||
                randNum == randNum2 && input != "=")
            {
                counter--;
                Console.WriteLine($"{input} is wrong answer");
                Console.WriteLine($"Score:{counter}");
            }

            if (counter < 10)
            {
                Run();
            }
            else if (counter == 10)
            {
                Console.WriteLine($"Congrats, your score is :{counter}, you win");
            }

        }
    }
}

