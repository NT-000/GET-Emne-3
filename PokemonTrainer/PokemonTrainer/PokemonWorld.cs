using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    internal class PokemonWorld
    {

        List<Pokemon> StartPokemon { get; set; } = Pokemon.GetStartPokemon();

        Random _random = new Random();
        private PokeGym _gym = new PokeGym();
        public static List<Pokemon> GrassPokemons { get; set; }
        private string Grass { get; set; }
        private string Mud { get; set; }
        private string Water { get; set; }

        private string Input { get; set; }

        private int InputInt { get; set; }
        public PokemonWorld()
        {
            MenuWorld();
        }

        public void MenuWorld()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hi, what's your name?");
            Input = Console.ReadLine();
            var _myTrainer = new Trainer($"{Input}", "From X-Town");
            var _pikachu = new Pokemon("Pikachu", 10, 50,12, 15,"Electric");
            GrassPokemons = _pikachu.GenerateManyRandomGrassPokemon(_random, 10);
            _pikachu.GenerateRandomGrassPokemon(_random);
            FirstEncounter(_myTrainer, _pikachu);
            ShowStartPokemon(_myTrainer);
                bool isRunning = true;
                while (isRunning)
                {
                    Console.WriteLine("1.Go to the forrest");
                    Console.WriteLine("2.Go to the lake");
                    Console.WriteLine("3.Go the the gym");
                    Console.WriteLine("4.Retire");
                    Console.WriteLine("5.Show Pokemon\n");
                    var input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                    case 1:
                        Console.WriteLine("Go to the forrest");
                        break;
                    case 2:
                        Console.WriteLine("Go to the lake");
                        break;
                    case 3: Console.WriteLine("gym");
                        _myTrainer.Environment = "gym"; 
                        _gym.GymMenu(_myTrainer);
                        break;
                    case 4: Console.WriteLine("retire");
                        isRunning = false;
                        break;
                    case 5:
                        _myTrainer.ShowTrainerPokemon(_myTrainer);
                        break;
                    }
                }
        }

        public void FirstEncounter(Trainer _trainer, Pokemon pikachu)
        {
            Console.WriteLine($"{_trainer.Name}, you have encountered a wild Pokemon that has taken a likening to you!");
            Console.WriteLine($"Do you want to adopt this wild {pikachu.Name}?");
            Input = Console.ReadLine();
            if (Input == "yes")
            {
                Console.WriteLine($"{pikachu.Name} in level {pikachu.Level} added to your pokemons!");
                _trainer.GetTrainerPokemon().Add(pikachu);
            }
            else
            {
                Console.WriteLine($"{pikachu.Name} ran into the forrest, lost forever...");
            }
        }

        public void ShowStartPokemon(Trainer _trainer)
        {
            int counter = 1;
            Console.WriteLine($"Choose your pokemon");
            foreach (var pokemon in StartPokemon)
            {
                Console.WriteLine($"{counter}.{pokemon.Name}");
                counter++;
            }

            InputInt = int.Parse(Console.ReadLine()); 
            var chosenPokemon = StartPokemon[InputInt - 1];
            _trainer.GetTrainerPokemon().Add(chosenPokemon);
            Console.WriteLine($"{chosenPokemon.Name} added to you pokemons");
        }



    }

}
