using System.Security.Cryptography.X509Certificates;

namespace ST_Tes;

public abstract class InventoryItem
{
    public string Name {get;private set;}
    public int Quantity {get;private set;}
    public double Price {get;private set;}

    public static int Num { get; set; } = 1;

    public double Sum {get; protected set;}
    
    public double SalePrice {get; protected set;}
    
    public double RandomValue {get; protected set;}

    public string line = new string('_', 60);

    public double[] Percentages { get; private set; } = [0.3,0.4,0.5,0.6,0.7,0.8,0.9];
    
    public InventoryItem(string name, int quantity, double price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }
    public static void ResetCounter()
    {
        Num = 1;
    }
    public int SetQuantity(int quantity)
    {
       return Quantity = quantity;
    }

    public virtual void Show()
    {
        Console.WriteLine($"{Num++}.{Name} | Quantity: {Quantity} | Price: {Price}");
        Console.WriteLine($"SALE!! {RandomValue * 100:f2}% off - New price: {SalePrice} kr\n");
    }
    public double CreateRandomValue()
    {
        var index = new Random().Next(0,Percentages.Length);
        var percentage = Percentages[index];
        RandomValue = 1 - percentage;
        return percentage;
    }
    public abstract InventoryItem CreateNewItem(int quantity);


}