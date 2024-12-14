namespace Lagerstyring_App
{
    internal class Clothing : IProduct
    {
        public string Name { get; }
        public double Price { get; }
        private string Size { get; set; }

        public string Category { get; set; }
        public int Quantity { get; set; }
        string stringLine = new string('-', 60);
        string overViewProducts = $"{"Name",-20} {"Price",-10} {"Category",-15} {"Quantity",-10}";

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
            int counter = 1;
            Console.WriteLine("Clothing section");
            Console.Clear();
            Console.WriteLine($"{overViewProducts}");
            Console.WriteLine($"{stringLine}");
            var clothingItems = _products.Where(item => item.Category == "Clothing").ToList();

            foreach (Clothing item in clothingItems)
            {
                Console.WriteLine($"{counter}.{item.Name,-20} {item.Price,-10} {item.Category,-15} {item.Quantity,-10} {item.Size} ");
                counter++;
            }

            Console.WriteLine("Do you want to add more of the chosen item?");
            Console.WriteLine("1 for 'yes' or 2 for 'no'");
            var input = Convert.ToInt32(Console.ReadLine());
            if (input == 0)
            {
                return;
            }
            if (input == 1)
            {
                Console.WriteLine("You chose to add to stock.");
                Console.WriteLine("Which item do you want to add?");
                input = Convert.ToInt32(Console.ReadLine()); ;
                if (input != null)
                {
                    var chosenItem = clothingItems[input - 1];

                    Console.WriteLine($"How many {chosenItem.Name} would you like to add to storage? You currently have: {chosenItem.Quantity}");
                    input = Convert.ToInt32(Console.ReadLine());

                    chosenItem.Quantity += input;
                    Console.WriteLine($"New stock of {chosenItem.Name} is {chosenItem.Quantity}");
                }

            }
            else
            {
                Console.WriteLine("You chose to go");
            }

        }

    }
}
