using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyring_App
{
    internal class ViewMenu
    {
        private List<IProduct> _products;

        public ViewMenu()
        {
            StartMenu();

        }

        void StartMenu()
        {   
            Console.Clear();
            Console.WriteLine("Storage room");
            Console.WriteLine("1.Storage");
            Console.WriteLine("2.Go to sections");
            Console.WriteLine("3.Remove Item");
            Console.WriteLine("4.Show inventory");
            while (true)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.WriteLine("Storage");
                        new StorageRoom().ShowInventory();
                        break;
                    case '2':
                        Console.WriteLine("Go to sections");
                        StorageMenu();
                        break;
                    case '3':
                        Console.WriteLine("Remove item");
                        break;
                    case '4':
                        Console.WriteLine("Show inventory");
                        break;

                }
            }
        }


        void StorageMenu()
        {
            Console.WriteLine("Welcome to our storage facility");
            while (true)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        new Clothing().PrintInfo(_products);
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;

                }
            }
        }

    }
}
