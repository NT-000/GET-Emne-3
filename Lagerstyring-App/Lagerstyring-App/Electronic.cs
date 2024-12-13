using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyring_App
{
    internal class Electronic : IProduct
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Warranty { get; private set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        
        public void PrintInfo(List<IProduct> _products)
        {
            Console.WriteLine($"Welcome to Electronics section:");
            foreach (Electronic item  in _products)
            {
                Console.WriteLine($"{item.Name} Quantity: {item.Quantity}");
            }
        }


    public Electronic(string name, int price, int warranty, int quantity, string category)
        {
            Name = name;
            Price = price;
            Warranty = warranty;
            Quantity = quantity;
            Category = category;
        }
 
    }
}
