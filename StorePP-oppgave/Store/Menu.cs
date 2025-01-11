namespace ST_Tes;

public class Menu
{
    public string[] menu = ["1.Show store inventory","2.Show user inventory", "3.Buy item","4.Sell item", "5.Show Personalia"];
    public void UnpackMenu()
    {
        Console.WriteLine("Welcome to the store!");
        for (int i = 0; i < menu.Length; i++)
        {
            Console.WriteLine(menu[i]);
        }
    }
    public void StartMenu(ActionManager actionManager, User user)
    {
        
        while (true)
        {   InventoryItem.ResetCounter();
            UnpackMenu();
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    actionManager.ShowStoreInventory(user);
                    break;
                case 2:
                    actionManager.ShowInventory(user);
                    break;
                case 3:
                    actionManager.BuyItem(user);
                    break;
                case 4:
                    actionManager.SellItem(user);
                    break;
                case 5:
                    actionManager.ShowPersonalInfo(user);
                    break;
            }
            
        }
    }
}