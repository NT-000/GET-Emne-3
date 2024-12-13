using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyring_App
{
    internal class Clothing : IProduct
    {
        public string Name { get; }
        public double Price { get; }
        private string Size { get; set; }

        public string Category { get; set; }
        public int Quantity { get; set; }

        public Clothing()
        {

        }
        public Clothing(string name, double price, string size, string category, int quantity)
        {
            Name = name;
            Price = price;
            Size = size;
            Category = category;
            Quantity = quantity;

        }
        public void PrintInfo(List<IProduct> _products)
        {
            Console.WriteLine("Clothing section");
            foreach (Clothing rag in _products)
            {
                Console.WriteLine($"{rag.Name} - {rag.Category} - {rag.Price} - {rag.Quantity} - {rag.Size}");
            }
        }
    }
}
