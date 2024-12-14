namespace Lagerstyring_App
{
    internal class Electronic : IProduct
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Warranty { get; private set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        string stringLine = new string('-', 60);

        public void PrintInfo(List<IProduct> _products)
        {

            Console.WriteLine("Food section");
            Console.Clear();
            Console.WriteLine($"{"Name",-20} {"Price",-10} {"Category",-15} {"Quantity",-10}");
            Console.WriteLine($"{stringLine}");
            var electronicItems = _products.Where(item => item.Category == "Electronics").ToList();
            int counter = 1;
            foreach (Electronic e in electronicItems)
            {
                Console.WriteLine($"{counter}.{e.Name,-20} {e.Price,-10} {e.Category,-15} {e.Quantity,-10} {e.Warranty} ");
                counter++;
            }
            Console.WriteLine("Do you want to add more of the chosen item?");
            Console.WriteLine("1 for 'yes' or 2 for 'no'");
            var input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                Console.WriteLine("You chose to add to stock.");
                Console.WriteLine("Which item do you want to add?");
                input = Convert.ToInt32(Console.ReadLine());
                var chosenItem = electronicItems[input - 1];
                Console.WriteLine($"How many {chosenItem.Name} would you like to add to storage? You currently have: {chosenItem.Quantity}");
                int inputNum = Convert.ToInt32(Console.ReadLine());
                chosenItem.Quantity += inputNum;
                Console.WriteLine($"New stock of {chosenItem.Name} is {chosenItem.Quantity}");
            }
            else
            {
                Console.WriteLine("Bye");
            }
        }

        public Electronic()
        {

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
