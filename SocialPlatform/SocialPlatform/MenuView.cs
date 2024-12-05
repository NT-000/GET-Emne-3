using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform
{
    internal class MenuView
    {
        public MenuView()
        {
            var p1 = new People("Jon", 31, "Masvo", "123");
            var p2 = new People("Jonny", 31, "Masvo2", "123");
            var p3 = new People("Jonas", 31, "Masvo3", "123");

            bool isRunning = true;
            while (isRunning)
            {
                var inputChoice = int.Parse(Console.ReadLine());
                switch (inputChoice)
                {
                    case 1:
                        p1.ShowPeople();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}
