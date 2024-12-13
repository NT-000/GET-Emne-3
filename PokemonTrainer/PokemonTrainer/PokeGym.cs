using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    internal class PokeGym
    {
        public static int TurnCounter = 0;

        private Trainer SelectedTrainer { get; set; }
        private string InputString;
        public PokeGym() { }

        public PokeGym(string gym)
        {
        }

        public void GymMenu(Trainer _trainer)
        {
            var GymTrainer1 = new Trainer("James", new List<Pokemon>
            {
                new Pokemon("Oddish", 25, 30, 30, 10, "Grass"),
                new Pokemon("Bulbasaur", 5, 30, 10, 10, "Grass"),
            });

           bool isRunning = true;
            while (isRunning)
            {
                InputString = Console.ReadLine(); 
                switch (InputString)
                {
                    case "1":
                        SelectedTrainer = GymTrainer1;
                        Console.WriteLine($"{GymTrainer1.GetTrainerPokemon()[0]}");
                        _trainer.ShowTrainerPokemon(_trainer);
                        GymTrainer1.SelectedPokemon = GymTrainer1.GetTrainerPokemon()[0];
                        StatusBar(_trainer, SelectedTrainer);
                        //_trainer.Battle();
                        break;

                    case "2":
                        break;
                    case "3":
                        break;

                    
                }

            }
        }

        public void StatusBar(Trainer _trainer, Trainer selectedTrainer)
        {
            
            Console.Clear();
            Console.WriteLine("\nBATTLE");
            Console.WriteLine($"Name: {SelectedTrainer.SelectedPokemon.Name}");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Name: {_trainer.SelectedPokemon.Name} Lvl: {_trainer.SelectedPokemon.Level} Hp: {_trainer.SelectedPokemon.HpBar()} hp {_trainer.SelectedPokemon.Hp}  maxhp: {_trainer.SelectedPokemon.MaxHp}");
            Console.ResetColor();

            TestDmg(_trainer);
        }

        public void TestDmg(Trainer _trainer)
        {   var trainerPokemonHp = _trainer.SelectedPokemon.GetHp();
           trainerPokemonHp  -= _trainer.SelectedPokemon.Attack;
            Console.WriteLine($"{_trainer.SelectedPokemon.Attack} dmg");
            Console.WriteLine($"{trainerPokemonHp} of {_trainer.SelectedPokemon.MaxHp}");
        }
    }
}
