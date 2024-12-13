using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class PokeBall
    {
        private int Price { get; set; }
        private int Strength { get; set; }

        private string Name { get; set; }


        public PokeBall()
        {

        }
        public PokeBall(string name, int price, int strength)
        {
            Name = name;
            Price = price;
            Strength = strength;
        }

    }
}
