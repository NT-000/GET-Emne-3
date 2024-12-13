using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyring_App
{
    internal class StorageRoom
    {
        private List<IProduct> _products { get; set; }

        public StorageRoom()
        {
            _products = [
                new Clothing("Jeans", 500, "XL", "Clothing",221),
                new Clothing("Jeans", 500, "S", "Clothing",343),
                new Clothing("Sweater", 400, "L", "Clothing",454),
                new Clothing("Shoes", 700, "L", "Clothing",100),
                new Food("Milk", 20, "Food", 150, new DateOnly(2024,12,26)),
                new Food("Butter", 22, "Food", 45, new DateOnly(2025,01,15)),
                new Food("Sausage", 42, "Food", 200, new DateOnly(2024,12,25)),
                new Food("Steak", 200, "Food", 122, new DateOnly(2025,01,12)),
                new Electronic("PS5", 5000, 24, 100, "Electronics"),
                new Electronic("IPhone", 7000, 3,234,"Electronics"),
                new Electronic("Laptop", 15000, 24,170, "Electronics"),
                new Electronic("TV '65'", 12000, 24, 120, "Electronics"),
            ];

        }

        public void AddItem()
        {
            int counter = 1;
            Console.WriteLine("Add Item");
            foreach (var item in _products)
            {
                Console.WriteLine($"{counter}.{item.Name,-20} {item.Price,-10} {item.Category,-15} {item.Quantity,-10}");
            }

            var chosenItem = _products[Console.ReadKey().KeyChar - 1];
            Console.WriteLine($"");

        }

        public void RemoveItem()
        {
            foreach (var item in _products)
            {

            }
        }

        public void ShowInventory()
        {
            var stringLine = new string('-', 60);
            Console.WriteLine($"{"Name",-20} {"Price",-10} {"Category",-15} {"Quantity",-10}");
            Console.WriteLine($"{stringLine}");
            foreach (var item in _products)
            {
                Console.WriteLine($"{item.Name,-20} {item.Price,-10} {item.Category,-15} {item.Quantity,-10}");
            }
            Console.WriteLine($"{stringLine}");
        }
    }
}
