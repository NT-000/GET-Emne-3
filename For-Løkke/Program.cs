namespace For_Løkke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, ForLoop that prints Terje er kul cinco times");

            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine("Terje er kul");
            }

            string[] wordSalad =
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j"
            };
            foreach (var letter in wordSalad)
            {
                Console.WriteLine($"Letter: {letter}");
            }
            int counter = 0;
            bool runMF = true;
            while (runMF)
            {
                counter++;
                Console.WriteLine($"Round number: {counter}");
                if (counter >= 10)
                {
                    Console.WriteLine();
                    runMF = false;
                }
            }
            

        }
    }
}


