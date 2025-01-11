namespace ST_Tes;

public class User
{
    public Guid UserId { get;private set; }
    public string Name { get;private set; }
    public double Money { get;private set; }
    
    public List<InventoryItem> Inventory { get;private set; }

    public User(string name)
    {
        UserId = Guid.NewGuid();
        Name = name;
        Money = 100000;
        Inventory = 
            [
            new ClothingItem("Slippers", 20, 200, "L","Red"),
            ];
    }

    public double GetMoney()
    {
        return Money;
    }

    public double PayMoney(double amount)
    {
        return Money -= amount;
    }

    public double EarnMoney(double amount)
    {
        return Money += amount;
    }
}