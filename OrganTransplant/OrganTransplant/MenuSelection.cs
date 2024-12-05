using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace OrganTransplant
//{
//    internal class MenuSelection
//    {
//        private Hospital check = new();
//        private Persons bloodMatches = new();

//        private List<Persons> matchedList;

//        private OperationRoom operate = new OperationRoom();

//        public MenuSelection()
//        {
//            matchedList = bloodMatches.GetBloodMatches();
//        }

//        private string InputChoice { get; set; }
//        private SelectedUsers _selectedUsers { get; }
//    }
//        public void GetMenu1()
//        {
//            var bernt = _selectedUsers.SelectedBernt;
//            bool menuIsRunning = true;
//            while (menuIsRunning)
//            {   
//                Console.WriteLine($"\nWelcome to the Hospital, {bernt.GetFirstName()}");
//                Console.WriteLine("1.All donors");
//                Console.WriteLine("2.Doctors currently on shift");
//                Console.WriteLine("3.Available matches, prep for surgery");
//                Console.WriteLine("4.Journal Bernt\n");
//                Console.WriteLine("5.Operate");
//                Console.WriteLine("6.Exit");
//                InputChoice = Console.ReadLine();

//                switch (InputChoice)
//                {
//                    case "1":
//                        Console.Clear();
//                        Program.GetInfo();
//                        break;
//                    case "2":
//                        Console.Clear();
//                        Program.GetInfoDoctors();
//                        break;
//                    case "3":
//                        Console.Clear();
//                        Console.WriteLine($"{check.CheckBloodtype()};");
                        
//                        break;
//                    case "4":
//                        Console.Clear();
//                        bernt.GetInfoSelectedPerson();
//                        break;
//                    case "5":
//                        Console.WriteLine("Operation");
                        
//                        operate.MenuOperation();
//                        break;
//                    case "6":
//                        Console.Clear();
//                        menuIsRunning = false;
//                        break;
                        
//                }
//            }



//    }



 


//    }
//}
