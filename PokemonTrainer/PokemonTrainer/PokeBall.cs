using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    internal class PokeBall
    {   
        private int Price {get; set;}
        private int Strength {get; set;}
        public PokeBall(int price, int strength){ 
            Price = price;
            Strength = strength;
        }

        public PokeBall _PokeBall()
        {
            return new PokeBall(100, 5);
        }
        public PokeBall GreatBall()
        {
            return new PokeBall(200, 10);
        }
        public PokeBall UltraBall()
        {
            return new PokeBall(400, 20);
        }
    }
}
