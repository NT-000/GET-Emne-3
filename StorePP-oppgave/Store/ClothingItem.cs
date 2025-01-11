namespace ST_Tes;

public class ClothingItem : InventoryItem, ISellable
{
    public string Size {get;private set;}
    public string Color {get;private set;}

    public ClothingItem(string name, int quantity, double price,string size, string color) : base(name, quantity, price)
    {
        Size = size;
        Color = color;
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
        Console.WriteLine($"Size: {Size} | Color: {Color}");
    }

    public override InventoryItem CreateNewItem(int quantity)
    {
        return new ClothingItem(Name, quantity, Price, Size, Color);
    }

}