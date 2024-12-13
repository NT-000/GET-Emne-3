using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyring_App
{
    internal class Food : IProduct
    {
        public string Name { get; }
        public double Price { get; }

        public string Category { get; set; }

        private DateOnly ExpirationDate { get; set; }

        public int Quantity { get; set; }
        public void PrintInfo(List<IProduct> _products)
        {
            Console.WriteLine("Food section");
            foreach (Food f in _products)
            {
                Console.WriteLine($"{f.Name} - {f.Category} - {f.ExpirationDate} - {f.Price} - {f.Quantity}");
            }
        }

        public Food(string name, double price, string category, int quantity, DateOnly expirationDate)
        {
            Name = name;
            Price = price;
            Category = category;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }
    }
}
