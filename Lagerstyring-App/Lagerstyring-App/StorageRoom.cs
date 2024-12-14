using System.Xml.Linq;

namespace Lagerstyring_App
{
    internal class StorageRoom
    {
        private string inputCategoryName;
        private int inputInt;
        string stringLine = new string('-', 60);
        public StorageRoom(List<IProduct> _products)
        {

        }

        public void AddProduct(List<IProduct> _products)
        {
            string[] categories = ["Clothing", "Electronics", "Food"];
            Console.WriteLine("Add product");
            Console.WriteLine("Enter productName");
            var inputName = Console.ReadLine();
            Console.WriteLine("What's the price of the item?");
            var inputPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input quantity of product");
            inputInt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter category");
            Console.WriteLine("1.Clothing - 2.Electronics - 3.Food");
            var inputCategoryNum = Convert.ToInt32(Console.ReadLine());
            if (inputCategoryNum == 1)
            {
                AddClothes(_products, inputName, inputPrice, categories);
            }
            else if (inputCategoryNum == 2)
            {
                AddElectronics(_products, inputName, inputPrice, categories);
            }
            else if (inputCategoryNum == 3)
            {
                AddFood(_products, inputName, inputPrice, categories);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }


        }

        private void AddClothes(List<IProduct> _products, string? inputName, int inputPrice, string[] categories)
        {
            string[] sizes = ["S", "M", "L", "XL", "XXl"];
            Console.WriteLine("Enter size");
            Console.WriteLine("1.Small - 2.Medium - 3.Large - 4.X-Large - 5. XX-Large");
            int inputSize = Convert.ToInt32(Console.ReadLine());
            if (inputSize == 0 || 5 < inputSize)
            {
                Console.WriteLine("Invalid input, enter 1-5.");
            }
            else
            {
                _products.Add(new Clothing(inputName, inputPrice, inputCategoryName, categories[0], inputInt));
                Console.WriteLine($"\nYou just added:\nName:{inputName}\nCategory:{categories[0]}\nPrice:{inputPrice}\nQuantity:{inputInt}\nSize:{sizes[inputSize - 1]}");
            }
        }

        private void AddElectronics(List<IProduct> _products, string? inputName, int inputPrice, string[] categories)
        {
            Console.WriteLine("How many months warranty?");
            int inputMonths = Convert.ToInt32(Console.ReadLine());
            _products.Add(new Electronic(inputName, inputPrice, inputMonths, inputInt, categories[1]));
            Console.WriteLine($"\nYou just added:\nName:{inputName}\nCategory:{categories[1]}\nPrice:{inputPrice}\nQuantity:{inputInt}\nWarranty:{inputMonths}");
        }

        private void AddFood(List<IProduct> _products, string? inputName, int inputPrice, string[] categories)
        {
            Console.WriteLine("Expiration date");
            Console.WriteLine("What day?");
            int exDay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What month?");
            int exMonth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What year?");
            int exYear = Convert.ToInt32(Console.ReadLine());
            _products.Add(new Food(inputName, inputPrice, categories[2], inputInt, new DateOnly(exYear,exMonth,exDay)));
            Console.WriteLine($"\nYou just added:\nName:{inputName}\nCategory:{categories[2]}\nPrice: {inputPrice}\nQuantity:{inputInt}\nExpiration date:{exDay}.{exMonth}.{exYear}");
        }

        public void RemoveProduct(List<IProduct> _products)
        {
            int counter = 1;
            Console.WriteLine("Would you like to remove a product? 1 for 'yes' or 2 for 'no'");
            var input = Convert.ToInt32(Console.ReadLine());
            
            if (input == 1)
            {
                Console.WriteLine($"You chose yes\n");
                foreach (var item in _products)
                {
                    Console.WriteLine(
                        $"{counter++}.{item.Name,-20} {item.Price,-10} {item.Category,-15} {item.Quantity,-10}");
                }

                Console.WriteLine("Which product would you like to remove?");
                int inputNum = Convert.ToInt32(Console.ReadLine());
                var chosenProduct = _products[inputNum - 1];
                _products.Remove(chosenProduct);
                Console.WriteLine($"You just removed {chosenProduct.Name}");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        public void ShowInventory(List<IProduct> _products)
        {
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
