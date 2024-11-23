using System;
using Overloads;

class Program
{
    static void Main(string[] args)
    {
        bool isTrue = true;
        while (isTrue)
        {
            var message = new Message();
            message.PrintWelcomeMessage();
            Console.WriteLine("Velg et kompliment!");
            Console.WriteLine("1: du er kul");
            Console.WriteLine("2: du er flink!");
            Console.WriteLine("3: du kler raske briller!");
            var input = Console.ReadLine();
            string option1 = "\ndu er kul\n";
            string option2 = "\ndu er flink!\n";
            string option3 = "\ndu kler raske briller!\n";

            switch (input)
            {
                case "1":
                    Console.Clear();
                    message.PrintWelcomeMessage(compliment: option1);
                    break;
                case "2":
                    Console.Clear();
                    message.PrintWelcomeMessage(compliment: option2);
                    break;
                case "3":
                    Console.Clear();
                    message.PrintWelcomeMessage(compliment: option3);
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Exiting...");
                    isTrue = false;
                    break;
                default:
                    Console.WriteLine("\nBare 1,2 eller 3!");
                    Console.Clear();
                    message.PrintWelcomeMessage(message.defCompliment);
                    break;
            }
        }
    }

}