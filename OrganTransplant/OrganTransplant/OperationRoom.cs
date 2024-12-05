using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganTransplant
{
    internal class OperationRoom
    {
        private Random _random = new();
        private SelectedUsers _selectedUsers;
        private List<Doctor> _doctors { get; set; }
        private List<Persons> _matchedList { get; set; }


        public OperationRoom()
        {

        }
        public OperationRoom(List<Persons> matchedList, List<Doctor> doctors, Persons selectedBernt)
        {

            _matchedList = matchedList;
            _doctors = doctors;
            _selectedUsers = new SelectedUsers(selectedBernt);

        }

        public void MenuOperation()
        {
            bool isRunning = true;
             

            while (isRunning)
            {

                Console.Clear(); Console.WriteLine("1.Select Donor");
            Console.WriteLine("2.Select Doctor");
            Console.WriteLine("3.Operate");
            Console.WriteLine("4.Journal of Bernt");
            Console.WriteLine("5.Exit");
            Console.WriteLine("-----------------------------------------------------");
            var inputChoice = Console.ReadLine();

                switch (inputChoice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Select Donor:");
                      _selectedUsers.SelectDonor(_matchedList);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Select Doctor:");
                        _selectedUsers.SelectDoctor(_doctors);
                        break;
                    case "3":
                        if (_selectedUsers.SelectedDonor == null || _selectedUsers.SelectedDoctor == null)
                        {
                            Console.Clear();
                            Console.WriteLine("Please select both a donor and a doctor before proceeding.");
                        }
                        else
                        {   Console.Clear();
                            CalculateOperationChance();
                        }
                        break;
                    case "4":
                        Console.Clear();
                        var bernt = Program.GetBernt();
                        bernt.GetInfoSelectedPerson();
                        break;
                    case "5":
                        Console.WriteLine("Shutting down...");
                        isRunning = false;
                        break;

                }
            }
        }
        public void CalculateOperationChance()
        {
            var bernt = Program.GetBernt();
            var suClass = _selectedUsers;
            Console.WriteLine("You have selected:");
            Console.WriteLine($"Donor:{suClass.SelectedDonor.GetFirstName()} {suClass.SelectedDonor.GetLastName()}");
            Console.WriteLine($"Doctor: {suClass.SelectedDoctor.GetDoctorLastName()}, {suClass.SelectedDoctor.GetDoctorName()}");
            if (_selectedUsers.GetSelectedDonor() != null && _selectedUsers.GetBernt() != null && _selectedUsers.GetSelectedDoctor() != null)
            {
               var chance = _selectedUsers.GetSelectedDoctor().GetDoctorSuccessRatio() + _selectedUsers.GetSelectedDonor().GetDonorSuccessRatio() + bernt.GetSuccessRatioBernt();
               var randomNum = _random.Next(1,101);

               Console.WriteLine($"Chance for success is {chance}%");
               Console.WriteLine(chance >= randomNum ? "Operation were a success!" : $"{suClass.SelectedBernt.GetFirstName()} died...");
            }
        }

    }
}
