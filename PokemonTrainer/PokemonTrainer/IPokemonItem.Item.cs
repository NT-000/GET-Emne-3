using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public abstract class IPokemonItems
    {
        public int id;
        public string name;
        public int price;
        public int quantity;
        private List<IPokemonItems> _itemsList = new List<IPokemonItems>();

        void run()
        {

        }
    }
}
