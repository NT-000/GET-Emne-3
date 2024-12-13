using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    internal class Pokemon
    {
        Random random = new Random();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Level { get; private set; }

        public int Hp { get; private set; }

        public int Attack { get; private set; }

        public int Defence { get; private set; }

        public string Type { get;private set; }

        public int MaxHp { get; set; }

        public Pokemon(string name, int level, int hp, int attack, int defence, string type)
        {
            Name = name;
            Description = "";
            Level = level;
            Hp = hp;
            MaxHp = Hp;
            Attack = attack;
            Defence = defence;
            Type = type;
        }



        public static List<Pokemon> GetStartPokemon()
        {
            return new List<Pokemon>(3)
            {
                new Pokemon("Bulbasaur", 5, 30, 10, 10, "Grass"),
                new Pokemon("Charmander", 5, 30, 10, 10, "Fire"),
                new Pokemon("Sqirtle", 5, 30, 10, 10, "Water")
            };
        }

        public void GenerateRandomGrassPokemon(Random random)
        {
            string[] names = ["Bulbasaur", "Ivysaur", "Venusaur", "Oddish", "Gloom",
                "Vileplume", "Bellsprout", "Weepinbell", "Victreebel", "Tangela"];
            

            int num = random.Next(names.Length);

            string name = names[num];
            int level = random.Next(5, 25);
            int hp = random.Next(30, 80);
            int attack = random.Next(8, 25);
            int defence = random.Next(8, 25);
            string type = "Grass";

            PokemonWorld.GrassPokemons.Add(new Pokemon(name, level, hp, attack, defence, type));
        }

        public List<Pokemon> GenerateManyRandomGrassPokemon(Random random,int number)
        {
            List<Pokemon> pokemons = new List<Pokemon>(); 
            string[] names = ["Bulbasaur", "Ivysaur", "Venusaur", "Oddish", "Gloom",
                "Vileplume", "Bellsprout", "Weepinbell", "Victreebel", "Tangela"];

            for (int i = 0; i < number; i++)
            {
                int num = random.Next(names.Length);
                string name = names[num];
                int level = random.Next(5, 25);
                int hp = random.Next(30, 80);
                int attack = random.Next(8, 25);
                int defence = random.Next(8, 25);
                string type = "Grass";
                pokemons.Add(new Pokemon(name, level, hp, attack, defence, type));
            }

            return pokemons;
        }

        public string HpBar()
        {
            string hpBar = "";
            int hpBlocks = Hp * 10 / MaxHp;

            for (var i = 0; i < hpBlocks; i++)
            {
                if (i < hpBlocks)
                {
                    hpBar += "\u258c";
                }
                else
                {
                    hpBar += "";
                }
            }
            if(Hp < 0.1 * MaxHp)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if(Hp < 0.5 * MaxHp)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            return hpBar;
        }

        public int GetHp()
        {
            return Hp;
        }

    }
}
