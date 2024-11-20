using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace TekstTukling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                
            

                Console.WriteLine("Hello, type 1 to reverse your text or 2 to change letters");
                var input = Console.ReadLine();
                Console.WriteLine($"Your word is: {input}");
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Write a text...");
                        var reverseInput = Console.ReadLine();
                        Console.WriteLine($"Reversed text:{reverseText(reverseInput)}");
                        break;
                    case "2":
                        Console.WriteLine("Type something...");
                        var text = Console.ReadLine();

                        Console.WriteLine("Letter to replace");
                        var oldLetter=Console.ReadLine();

                        Console.WriteLine("New letter");
                        var newLetter = Console.ReadLine();
                        Console.WriteLine($"{changeLetter(text, oldLetter[0], newLetter[0])}");
                        break;
                    default:
                        Console.WriteLine("Only 1 or 2");
                        break;

                }
                Console.WriteLine("Do you want to try again? y/n");
                string answer = Console.ReadLine();
                if (answer != "y")
                {
                    Console.WriteLine("Shutting down...");
                    break;
                }
            } while (true);
        }

        public static string reverseText(string reverseInput)
        {
            string reverse = "";
            for (var i = reverseInput.Length - 1; i >= 0; i--)
            {
                reverse += reverseInput[i];
            }
            return reverse;
        }

        public static string changeLetter(string text, char oldLetter, char newLetter)
        {
            return text.Replace(oldLetter, newLetter);
        }
    }
}
