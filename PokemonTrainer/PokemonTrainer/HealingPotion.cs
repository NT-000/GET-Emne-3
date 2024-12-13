using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{

    internal class ShopInventory
    {
        private int Price { get; set; }
        private int Strength { get; set; }
        private List<ShopInventory> _inventoryShopList { get; set; }

        public ShopInventory()
        {
            Price = 100;
            Strength = 10;
        }

    }
}
