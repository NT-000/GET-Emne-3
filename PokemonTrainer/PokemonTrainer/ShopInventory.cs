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

        public ShopInventory HealthPotion()
        {
            Price = 100;
            Strength = 10;
            return this;
        }
        private List<ShopInventory> initalizeList()
        {
            var pokeball = new PokeBall(100, 5);
            var greatball = new PokeBall.GreatBall();
            _inventoryShopList = new List<ShopInventory>();
            {
                PokeBall greatBall = PokeBall.GreatBall();
            }
        }
    }
}
