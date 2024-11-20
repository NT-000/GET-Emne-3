using System.Threading.Channels;

namespace Hva_gjør_koden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hei! Skriv inn et ord.");
            var range = 256;
            var counts = new int[range];
            string text = "something";

            while (!string.IsNullOrWhiteSpace(text))
            {
                text = Console.ReadLine();
                foreach (var character in text ?? string.Empty)
                {
                    char characterInput = char.ToUpper(character);
                    counts[(int)characterInput]++;
                }
                int total = 0;
                for (var i = 0; i < range; i++)
                {
                    total += counts[i];
                }

                Console.WriteLine("Should we right-adjust the text?");
                var input = Console.ReadLine();
                Console.WriteLine($"Bokstaver Totalt: {total}");
                for (var i = 0; i < range; i++)
                {
                    if (counts[i] > 0)
                    {
                        var character = (char)i;
                        double percentageOftotal = counts[i] / (double)total * 100;


                        if (input == "yes")
                        {
                            Console.WriteLine("");
                            Console.WriteLine(string.Format("{0,120}",
                                $"Bokstav: {character} - Antall: {counts[i]} Prosent av totalen: {percentageOftotal}%\n"));

                        }
                        else
                        {

                            Console.WriteLine($"{character} - Antall: {counts[i]} Prosent av totalen: {percentageOftotal}%\n");


                        }
                    }
                }
            }
        }
    }
}

//Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "John", "Roy", 40));

