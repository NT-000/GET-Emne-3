﻿namespace Random_HobbyGenerator
{
    internal class RandomHobbies
    {
      


    static void Run()
        {
            Random num = new();
            string[] Hobbies = { "Darts", "Martial Arts", "Magician", "Fishing", "Whistling", "Swimming", "Running", "Rollerskating", "Shooting" };
            int randomNum = num.Next(Hobbies.Length);
            string resultHobbies = Hobbies[randomNum];

            Console.WriteLine("Get a new hobby!");
            Console.WriteLine("What's your name?");
            string input = Console.ReadLine();
            Console.WriteLine($"{input} just discovered the new hobby {resultHobbies}");
        }
        static void Main(string[] args)
        {
            do
            {
                Run();
                Console.WriteLine("Would you like a new hobby? (y/n)");
                string answer = Console.ReadLine();
                if (answer != "y")
                {
                    Console.WriteLine("Bye then!");
                    break;
                }
            } while (true);
        }
    }
};