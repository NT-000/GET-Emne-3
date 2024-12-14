namespace Lagerstyring_App
{
    internal class ViewMenu
    {

        private List<IProduct> _products { get; set; }
        string stringLine = new string ('-', 60);

        public ViewMenu()
        {

            _products = [
                new Clothing("Mittens", 500, "XL", "Clothing",221),
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
                new Electronic("TV '55'", 14000, 24, 150, "Electronics"),
            ];
            StartMenu(_products);
        }

        void StartMenu(List<IProduct> _products)
        {
            var storageRoom = new StorageRoom(_products);

            while (true)
            {

                Console.WriteLine("\n1.Storage Inventory");
                Console.WriteLine("2.Go to different sections");
                Console.WriteLine("3.Remove product");
                Console.WriteLine("4.Add product");
                Console.WriteLine("5.Search for product");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.Clear();
                        storageRoom.ShowInventory(_products);
                        break;
                    case '2':
                        Console.Clear();
                        StorageMenu();
                        break;
                    case '3':
                        Console.Clear();
                        storageRoom.RemoveProduct(_products);
                        break;
                    case '4':
                        Console.Clear();
                        storageRoom.AddProduct(_products);
                        break;
                    case '5':
                        Console.Clear();
                        SearchMenu(_products);
                        break;

                }
            }
        }

        void SearchMenu(List<IProduct> _products)
        {
            Console.WriteLine("1.Search by product name and category");
            Console.WriteLine("2.Search by min and max price interval");
            bool isDone = true;
            while (isDone)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.Clear();
                        SearchForProduct(_products);
                        isDone = false;
                        break;

                    case '2':
                        Console.Clear();
                        SearchByPriceInterval(_products);
                        isDone = false;
                        break;
                }
            }
        }
        void StorageMenu()
        {
            bool isRunning = true;
            Console.Clear();
            Console.WriteLine("Welcome to our storage facility");
            Console.WriteLine("1.Clothing section");
            Console.WriteLine("2.Food section");
            Console.WriteLine("3.Electronic section");
            while (isRunning)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.Clear();
                        new Clothing().PrintInfo(_products);
                        isRunning = false;
                        break;
                    case '2':
                        Console.Clear();
                        new Food().PrintInfo(_products);
                        isRunning = false;
                        break;
                    case '3':
                        Console.Clear();
                        isRunning = false;
                        new Electronic().PrintInfo(_products);
                        break;
                    default:
                        isRunning = false;
                        break;

                }
            }
        }

        public void SearchForProduct(List<IProduct>_products)
        {
            Console.WriteLine("Search for any product in the storage inventory");

            Console.WriteLine("Search for name or category");
            string name = Console.ReadLine();
            var result =_products.Where(product => product.Name.ToUpper().Contains(name.ToUpper()) || product.Category.ToUpper().Contains(name.ToUpper())).ToList();

            result.Sort((a, b) => a.Name.CompareTo(b.Name));
            foreach (var product in result)
            {   

                Console.WriteLine($"\nName:{product.Name}\nCategory:{product.Category}\nQuantity:{product.Quantity}\nPrice:{product.Price}\n");
                Console.WriteLine($"{stringLine}");
            }

        }

        public void SearchByPriceInterval(List<IProduct> _products)
        {
            Console.WriteLine("Search for price interval");
            Console.WriteLine("Enter min price");
            int inputNum = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Enter max price");
            int inputNum2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Price range: {inputNum} - {inputNum2}");
            var result = _products.Where(product => inputNum <= product.Price && product.Price <= inputNum2).ToList();
            foreach (var product in result)
            {
                Console.WriteLine($"\nName:{product.Name}\nCategory:{product.Category}\nQuantity:{product.Quantity}\nPrice:{product.Price}\n");
                Console.WriteLine($"{stringLine}");
            }
        }

    }
}
