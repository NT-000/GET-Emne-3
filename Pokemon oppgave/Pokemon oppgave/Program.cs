// See https://aka.ms/new-console-template for more information

using Pokemon_oppgave;
using System;

namespace Pokemon_oppgave
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var pikachu = new Pokemon("Pikachu", 10, 2);
            var krabby = new Pokemon("Krabby", 20, 10);
            var hitmonlee = new Pokemon("Hitmonlee", 50, 30);
            

            do
            {
                Console.WriteLine("Which Pokeball do you choose? 1-3, or 4");
                Console.WriteLine("1.Electric Pokemon");
                Console.WriteLine("2.Water Pokemon");
                Console.WriteLine("3.Fighting Pokemon");
                Console.WriteLine("4.Pokemon Package");
                Console.WriteLine("5.Create a new Pokemon");
                Console.WriteLine("\nType '6' to quit.");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        pikachu.RevealPokemon();
                        break;
                    case "2":
                        krabby.RevealPokemon();
                        break;
                    case "3":
                        hitmonlee.RevealPokemon();
                        break;
                    case "4":
                        Console.WriteLine("All pokemon:");
                        krabby.RevealPokemon();
                        pikachu.RevealPokemon();
                        hitmonlee.RevealPokemon();
                        break;
                    case "5":
                        var newPokemon = Pokemon.CreatePokemon();
                        Console.WriteLine("\nYour new Pokemon just hatched...:");
                        Thread.Sleep(2000);
                        newPokemon.RevealPokemon();
                        Console.WriteLine("\n");
                        break;
                    case "6":
                        Console.WriteLine("You chose to exit, goodbye!");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("1-4 or 5 to exit...");
                        break;
                }
            } while (true);
        }
    }
}

