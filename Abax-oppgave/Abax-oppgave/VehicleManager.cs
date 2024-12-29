using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abax_oppgave
{
    internal class VehicleManager
    {
        public List<Vehicle> Vehicles { get;}

        public string line = new('_',60);
        public VehicleManager()
        {
            Vehicles =
            [
                new Car("NF123456",147,200,"Green", "Car", 1, "Light Car"),
                new Car("NF654321",150,195,"Blue","Car", 2, "Light Car"),
                new Boat("ABC123",100,30,500, 3, "Boat", "Cruiser"),
                new Plane("LN1234",1000,2000,10000,30,"Airplane", 4, "Jet")
            ];
        }

        public void ShowAllVehicles(ActionMenu aMenu)
        {
            Console.WriteLine("All vehicles");
            Console.WriteLine($"{line}");
            foreach (var v in Vehicles)
            {

                Console.WriteLine($"{v.Id}.{v.Type} - Class:{v.VehicleClass} - {v.PlateNumber}");
            }
            Console.WriteLine($"{line}");

            Console.WriteLine("Select one of the vehicles for more options.");
            var input = Convert.ToInt32(Console.ReadLine());
            if (input != null)
            {
                var chosenVehicle = Vehicles.Find(v => v.Id == input);
                Console.WriteLine($"You chose {chosenVehicle.Type} with platenumber {chosenVehicle.PlateNumber}");
                aMenu.VehicleInfo(chosenVehicle);
            }
            else
            {
                Console.WriteLine("Invalid input, try again");
            }
        }

        public void SearchForVehicleClass()
        {
            Console.WriteLine("Search for vehicle class");
            var input = Console.ReadLine().ToLower();
            var result = Vehicles.Where(v => v.VehicleClass.ToLower().Contains(input)).ToList();
            if (result.Any())
            {
                foreach (var v in result)
                {
                    Console.WriteLine($"Vehicle:{v.Type} - Class:{v.VehicleClass} - HP:{v.Effect} - Platenumber:{v.PlateNumber}");
                }
            }
            else
            {
                Console.WriteLine("no matches found, try again.");
            }
        }

        private void SearchForHPRange()
        {
            Console.WriteLine("Search for min and max HP range\n");
            Console.WriteLine("Enter min HP");
            var input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter max HP");
            var input2 = Convert.ToInt32(Console.ReadLine());
            var result = Vehicles.Where(v => input <= v.Effect && v.Effect <= input2).ToList();
            if (result.Any())
            {
                foreach (var v in result)
                {
                    Console.WriteLine($"Vehicle:{v.Type} Class:{v.VehicleClass} HP:{v.Effect}");
                }
            }
            else
            {
                Console.WriteLine("No matches found, try again.");
            }
        }

        private void SearchType()
        {
            Console.WriteLine("Search for type of vehicle\n");
            var input = Console.ReadLine().ToLower();
            var result = Vehicles.Where(v => v.Type.ToLower().Contains(input)).ToList();
            if (result.Any())
            {
                foreach (var v in result)
                {
                    Console.WriteLine($"Vehicle:{v.Type} - HP:{v.Effect} - Class:{v.VehicleClass} - Platenumber:{v.PlateNumber} ");
                }
            }
            else
            {
                Console.WriteLine("No matches found, try again.");
            }
        }

        public void SearchChoice()
        {
            Console.WriteLine("Search menu");
            Console.WriteLine($"{line}");
            Console.WriteLine("1.Search for type");
            Console.WriteLine("2.Search for amount of Horse Powers");
            Console.WriteLine("3.Search for vehicle class");
            Console.WriteLine($"{line}");

            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    Console.Clear();
                    SearchType();
                    break;
                case '2':
                    Console.Clear();
                    SearchForHPRange();
                    break;
                case '3':
                    Console.Clear();
                    SearchForVehicleClass();
                    break;
            }
        }
    }
}
