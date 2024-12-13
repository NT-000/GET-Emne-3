using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{   



    internal class Trainer
    {
        private Random random = new Random();
        public string Name {get; private set;}
        public string Description {get;private set;}
        List<Pokemon> _trainerPokemon { get; set; }
        private List<IPokemonItems> _items {get; set; }

        public string Environment { get; set; }

        private int InputChoice { get; set; }

        public Pokemon SelectedPokemon { get; set; }

        public Trainer(string name, string description)
        {
            Name = name;
            Description = description;
            _trainerPokemon = new List<Pokemon>();
            _items = new List<IPokemonItems>();
            SelectedPokemon = null;
            Environment = "none";
        }



        public Trainer()
        {
            Name = RandomName(random);
            _trainerPokemon = new List<Pokemon>();
            _items = new List<IPokemonItems>();
            SelectedPokemon = null;
        }

        public Trainer(string name, List<Pokemon> trainerPokemon)
        {
            Name = name;
            _trainerPokemon = trainerPokemon;
            _items = new List<IPokemonItems>();
            SelectedPokemon = null;
        }

        public string RandomName(Random random)
        {
            string[] name = ["Joe", "Ali", "Nico", "Beep"];
            int num = random.Next(name.Length);
            var chosenName = name[num];
            return chosenName;
        }

        public List<Pokemon> GetTrainerPokemon()
        {
            return _trainerPokemon;
        }

        public void ShowTrainerPokemon(Trainer _trainer)
        {
            int count = 1;
            Console.WriteLine("Your Pokemon:");
            foreach (var pokemon in _trainerPokemon)
            {
                Console.WriteLine($"{count}.{pokemon.Name} {pokemon.Level} {pokemon.Type}");
            }
            Console.WriteLine($"Current Environment: {Environment}");
            if (Environment == "gym" || Environment == "grass" || Environment == "water")
            {
                Console.WriteLine($"Pick your Pokemon to battle");
                InputChoice = int.Parse(Console.ReadLine());
                SelectedPokemon = _trainerPokemon[InputChoice - 1];
                Console.WriteLine($"You chose {SelectedPokemon.Name}");
                Console.WriteLine($"selectedPoke: {_trainer.SelectedPokemon.Name}");
            }
        }

        public Pokemon GetSelectedPokemon()
        {
            return SelectedPokemon;
        }
    }
}
