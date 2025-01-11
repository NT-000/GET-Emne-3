using System.Drawing;

namespace ST_Tes;

public class ElectronicItem : InventoryItem, ISellable
{
    public int Warranty { get;private set; }
    public int Voltage { get;private set; }

    public ElectronicItem(string name, int quantity, double price, int warranty, int voltage) : base(name, quantity, price)
    {
        Warranty = warranty;
        Voltage = voltage;
        SalePrice = CalculateSalePrice();
    }

    public double CalculateSalePrice()
    {
        Sum = Price * CreateRandomValue();
        return Sum;
    }
    public override void Show()
    {
        Console.WriteLine($"{line}");
        base.Show();
        Console.WriteLine($"Warranty: {Warranty} | Voltage: {Voltage}");
    }

    public override InventoryItem CreateNewItem(int quantity)
    {
        return new ElectronicItem(Name, quantity, Price, Warranty, Voltage);
    }
}