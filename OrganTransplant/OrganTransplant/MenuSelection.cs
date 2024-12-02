using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganTransplant
{
    internal class MenuSelection
    {
        private Hospital check = new();
        private static Persons SelectedPersonBernt {get; set; }
        private static Persons SelectedPerson { get;  }
        private static Doctor SelectedDoctor { get; set; }

        private static List<Persons> matchedList = Persons.GetBloodMatches();

        private OperationRoom operate = new OperationRoom();
        private string InputChoice { get; set; }

        public void GetMenu1()
        {
            var bernt = Program.GetBernt();
            SelectedPersonBernt = bernt;
            bool menuIsRunning = true;
            while (menuIsRunning)
            {   
                Console.WriteLine($"\nWelcome to the Hospital, {SelectedPersonBernt.GetFirstName()}");
                Console.WriteLine("1.All donors");
                Console.WriteLine("2.Doctors currently on shift");
                Console.WriteLine("3.Available matches, prep for surgery");
                Console.WriteLine("4.Journal Bernt\n");
                Console.WriteLine("5.Operate");
                Console.WriteLine("6.Exit");
                InputChoice = Console.ReadLine();

                switch (InputChoice)
                {
                    case "1":
                        Console.Clear();
                        Program.GetInfo();
                        break;
                    case "2":
                        Console.Clear();
                        Program.GetInfoDoctors();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine($"{check.CheckBloodtype()};");
                        
                        break;
                    case "4":
                        Console.Clear();
                        SelectedPersonBernt.GetInfoSelectedPerson();
                        break;
                    case "5":
                        Console.WriteLine("Operation");
                        
                        operate.MenuOperation();
                        break;
                    case "6":
                        Console.Clear();
                        menuIsRunning = false;
                        break;
                        
                }
            }



    }



 
        public void matchedDonorsMenu()
        {

        }

        //public static Persons GetMatchedDonor()
        //{
        //    return 
        //}


        public static Persons GetSelectedBernt()
        {
            return SelectedPersonBernt;
        }

        public static Doctor GetSelectedDoctor()
        {
            return SelectedDoctor;
        }

        public static List<Persons> matchedDonorList()
        {
            return matchedList;
        }
    }
}
