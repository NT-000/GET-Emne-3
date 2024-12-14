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
            var stringLine = new string('-', 60);
            Console.WriteLine("Food section");
            Console.Clear();
            Console.WriteLine($"{"Name",-20} {"Price",-10} {"Category",-15} {"Quantity",-10}");
            Console.WriteLine($"{stringLine}");
            var foodItems = _products.Where(item => item.Category == "Food").ToList();
            int counter = 1;
            foreach (Food f in foodItems)
            {
                Console.WriteLine($"{counter}.{f.Name,-20} {f.Price,-10} {f.Category,-15} {f.Quantity,-10} {f.ExpirationDate} ");
                counter++;
            }
            Console.WriteLine("Do you want to add more of the chosen item?");
            Console.WriteLine("1 for 'yes' or 2 for 'no'\n");
            var input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                Console.WriteLine("You chose to add to stock.");
                Console.WriteLine("Which item do you want to add?\n");
                input = Convert.ToInt32(Console.ReadLine());
                var chosenItem = foodItems[input - 1];
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

        public Food()
        {

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
