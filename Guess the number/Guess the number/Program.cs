using System.ComponentModel.DataAnnotations;

namespace Guess_the_number
{
    internal class Program
    {
        public static int _totalCount = 0;
        static void Main(string[] args)
        {
            do
            {
                Random randNum = new();
                var random = randNum.Next(1, 100);
                Console.WriteLine("Hello, type in a number between 1-100!");
                var inputNum = Console.ReadLine();
                var guessNum = int.Parse(inputNum);

                if (guessNum == random)
                {
                    Console.WriteLine($"You win, correct guess, Random number was: {random}!");
                    _totalCount++;
                    Console.WriteLine($"You got it in: {_totalCount} tries");
                }

                if (guessNum > random)
                {
                    Console.WriteLine($"Try again, lower... Random number was: {random}");
                    _totalCount++;
                    Console.WriteLine($"You have used guessed: {_totalCount} times");
                }

                if (guessNum < random)
                {
                    Console.WriteLine($"Try again, higher... Random number was: {random}");
                    _totalCount++;
                    Console.WriteLine($"You have used guessed: {_totalCount} times");
                }
            } while (true);
        }
    }
}
