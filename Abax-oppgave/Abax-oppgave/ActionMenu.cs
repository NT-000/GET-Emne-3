namespace Abax_oppgave
{
    internal class ActionMenu
    {

        public ActionMenu()
        {
        }

      public void StartMenu(VehicleManager vManager)
        {
            while (true)
            {
                Console.WriteLine("Hi and welcome to the All Vehicles AutoShop!");
                Console.WriteLine("1.Show vehicles");
                Console.WriteLine("2.Search for vehicle\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        vManager.ShowAllVehicles(this);
                        break;
                    case '2':
                        Console.Clear();
                        vManager.SearchChoice();
                        break;
                    case '3':
                        break;
                }
            }
        }


     public void VehicleInfo(Vehicle chosenVehicle)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n1.Show info");
                Console.WriteLine("2.Drive");
                Console.WriteLine("3.Go back\n");
                switch (Console.ReadKey(intercept: true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        chosenVehicle.ShowInfo();
                        break;
                    case '2':
                        Console.Clear();
                        chosenVehicle.Drive();
                        break;
                    case '3':
                        isRunning = false;
                        break;
                }
            }
        }
    }
}
