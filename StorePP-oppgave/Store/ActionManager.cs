namespace ST_Tes;

public class ActionManager
{
    public List<InventoryItem> StoreInventory { get; private set; }
    public string Line = new string('_', 60);

    public ActionManager()
    {
        StoreInventory =
        [
            new ClothingItem("T-shirt", 100, 125, "S", "Blue"),
            new ClothingItem("Shoes", 100, 220, "L", "Yellow"),
            new ClothingItem("Pants", 100, 110, "R", "Black"),
            new ClothingItem("Shirt", 100, 130, "M", "Black"),
            new ClothingItem("Jacket", 100, 1120, "XL", "Pink"),
            new ElectronicItem("PC", 100, 10000, 24, 240),
            new ElectronicItem("Sound system", 100, 12000, 24, 240),
            new ElectronicItem("Ipad", 100, 15000, 24, 240),
            new ElectronicItem("Headset", 120, 1500, 24, 240),

        ];
    }

    public void ShowStoreInventory(User user)
    {
        foreach (var i in StoreInventory)
        {
            i.Show();
            CheckStoreInventoryStock(i);
        }
        Console.WriteLine($"Your balance:{user.GetMoney()}kr\n");
    }

    public void CheckStoreInventoryStock(InventoryItem i)
    {
        if (i.Quantity == 0)
        {
            Console.WriteLine($"!!!{i.Name} IS SOLD OUT!!!");
        }
    }

    public void ShowInventory(User user)
    {
        Console.WriteLine("Your inventory:");
        foreach (var i in user.Inventory)
        {
            i.Show();
        }
    }
    public void BuyItem(User user)
    {
        ShowStoreInventory(user);
        Console.WriteLine("What item would you like to buy?");
        var input = Convert.ToInt32(Console.ReadLine()) - 1;
        var selectedItem = StoreInventory[input];

        Console.WriteLine($"How many of {selectedItem.Name} would you like to buy?");
        var input2 = Convert.ToInt32(Console.ReadLine());
        if (input2 > 0 && selectedItem.Quantity >= input2)
        {
                var newItem = selectedItem.CreateNewItem(input2);
                user.Inventory.Add(newItem);
                selectedItem.SetQuantity(selectedItem.Quantity - input2);
                Console.WriteLine($"You have bought {input2} of {selectedItem.Name}\nNew stock: {selectedItem.Quantity}");
                double cost = selectedItem.SalePrice * input2;
                Console.WriteLine($"Total cost: {cost} kr, each {cost / input2} kr\n");
                user.PayMoney(cost);
                Console.WriteLine($"New balance: {user.GetMoney()} kr\n");
        }
        else
        {
            Console.WriteLine("Invalid input, try again.");
        }
    }

    public void SellItem(User user)
    {
        Console.WriteLine("Your Inventory");
        Console.WriteLine($"{Line}");
        ShowInventory(user);
        Console.WriteLine("What item would you like to sell?");
        var input = Convert.ToInt32(Console.ReadLine()) - 1;
        var selectedItem = user.Inventory[input];
        Console.WriteLine($"How many of {selectedItem.Name} would you like to sell?");
        var input2 = Convert.ToInt32(Console.ReadLine());

        if (input2 > 0 && input2 <= selectedItem.Quantity)
        {
            selectedItem.SetQuantity(selectedItem.Quantity - input2);
            if (selectedItem.Quantity == 0)
            {
                user.Inventory.Remove(selectedItem);
                Console.WriteLine($"You have sold all {selectedItem.Name} in your inventory.");
            }
            else
            {
                Console.WriteLine($"You just sold {input2} of {selectedItem.Name}, your new stock: {selectedItem.Quantity}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input, try again.");
        }
    }

    public void ShowPersonalInfo(User user)
    {
        Console.WriteLine($"Name:{user.Name} | Balance: {user.Money} | UserId: {user.UserId}");
    }
}