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
        private readonly SelectedUsers _selectedUsers;
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
            Console.WriteLine("1.Select Donor");
            Console.WriteLine("2.Select Doctor");
            Console.WriteLine("3. Operate");
            Console.WriteLine("4. Exit");
            var inputChoice = Console.ReadLine();

                switch (inputChoice)
                {
                    case "1":
                        Console.WriteLine("Select Donor:");
                      _selectedUsers.SelectDonor(_matchedList);
                        break;
                    case "2":
                        Console.WriteLine("Select Doctor:");
                        _selectedUsers.SelectDoctor(_doctors);
                        break;
                    case "3":
                        if (_selectedUsers.SelectedDonor == null || _selectedUsers.SelectedDoctor == null)
                        {
                            Console.WriteLine("Please select both a donor and a doctor before proceeding.");
                        }
                        else
                        {
                            CalculateOperationChance();
                        }
                        break;

                    case "4":
                        Console.WriteLine("Shutting down...");
                        isRunning = false;
                        break;

                }
            }
        }
        public void CalculateOperationChance()
        {
            var suClass = _selectedUsers;
            Console.WriteLine("You have selected:");
            Console.WriteLine($"Donor:{suClass.SelectedDonor.GetFirstName()} {suClass.SelectedDonor.GetLastName()}");
            Console.WriteLine($"Doctor: {suClass.SelectedDoctor.GetDoctorLastName()}, {suClass.SelectedDoctor.GetDoctorName()}");
            if (_selectedUsers.GetSelectedDonor() != null && _selectedUsers.GetBernt() != null && _selectedUsers.GetSelectedDoctor() != null)
            {
               var chance = _selectedUsers.GetSelectedDoctor().GetDoctorSuccessRatio() + _selectedUsers.GetSelectedDonor().GetDonorSuccessRatio() + _selectedUsers.GetBernt().GetSuccessRatioBernt();
               var randomNum = _random.Next(1,101);

               Console.WriteLine($"Chance for success is {chance}%");
               Console.WriteLine(chance >= randomNum ? "Operation were a success!" : $"{suClass.SelectedBernt.GetFirstName()} died...");
            }
        }
        public void ChooseSelectedPerson(List<Persons> matchedList)
        {
            Console.Clear();
            Console.WriteLine($"Prepping for surgery, choose your donor:");
            Console.WriteLine("---------------------------------------------");
            for (int i = 0; i < _matchedList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_matchedList[i].GetFirstName()} \nLastname: {_matchedList[i].GetLastName()}\n");
            }
            Console.WriteLine($"{_matchedList.Count + 1}. Exit");
            int inputSwitch = int.Parse(Console.ReadLine());
            Persons _selectedPerson = _matchedList[inputSwitch];

            Console.WriteLine($"You chose donor {_selectedPerson.GetFirstName()} Lastname; {_selectedPerson.GetLastName()}");
        }
        public void ChooseSelectedDoctor(List<Doctor> doctors)
        {
            Console.WriteLine("Select your doctor");
            for (int i = 0; i < _doctors.Count; i++)
            {
                Console.WriteLine($"{i}.{_doctors[i].GetDoctorLastName()}, {_doctors[i].GetDoctorSuccessRatio()}");
            }
            Console.WriteLine($"{_doctors.Count + 1}. Exit");
            var inputSwitch = int.Parse(Console.ReadLine());
            Doctor _selectedDoctor = _doctors[inputSwitch];
            Console.WriteLine($"You chose Doctor: {_selectedDoctor.GetDoctorLastName()}, {_selectedDoctor.GetDoctorName()}\nSkill: {_selectedDoctor.GetDoctorSuccessRatio()}");
        }
    }
}
