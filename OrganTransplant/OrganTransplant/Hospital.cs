namespace OrganTransplant
{
    internal class Hospital
    {   
       public List<Persons> _potentialDonors { get;private set; }
       public int _operationSucces {get;private set;}
       public List<Doctor> doctors { get; private set; }
       private SelectedUsers _selectedUsers { get; set; }

        public string CheckBloodtype()
        {
            
            Console.WriteLine($"{_selectedUsers.SelectedBernt.GetFirstName()}");

            Console.WriteLine($"Checking blood type compatibility for:{_selectedUsers.SelectedBernt.GetLastName()}, {_selectedUsers.SelectedBernt.GetFirstName()} (Blood Type: {_selectedUsers.SelectedBernt.GetBloodType()})");
            string space = "------------------------------";
            var bloodMatches = _potentialDonors.Where(donor => donor.GetBloodType() == _selectedUsers.SelectedBernt.GetBloodType()).ToList();
            int count = 1;
            var matches = "";
            for (int i = 0; i < bloodMatches.Count;i++)
            {
                matches +=
                    $"\nSubject {count}\n{space}\n{bloodMatches[i].GetFirstName()} \nLastname: {bloodMatches[i].GetLastName()}\nBlood type: {bloodMatches[i].GetBloodType()}\n Chance for success: {bloodMatches[i].GetDonorSuccessRatio()}%";
                count++;
            }

            return bloodMatches.Count == 0 ? "No matches found." : matches;
        }



        public int CalculateBerntSuccess()
        {   
            var successRatio = 30;

            successRatio += GetSuccessAgeRate();
            successRatio += GetIfSmoker();
            successRatio += GetIfOverweight();
            successRatio += GetIfDiabetes();
            successRatio += GetIfAthletic();
            successRatio = Math.Clamp(successRatio, 0, 100);
            return successRatio;
        }

        private int GetSuccessAgeRate()
        {
            var bernt = _selectedUsers.SelectedBernt;
            {
                if (bernt.GetAge() < 35) return 30;
                if (bernt.GetAge() < 45) return 15;
                if (bernt.GetAge() < 55) return -5;
                if (bernt.GetAge() < 65) return -25;
                return -35;
            }
        }



        private int GetIfSmoker()
        {
            int SuccessRate = 0;
            if (_selectedUsers.SelectedBernt.GetSmoker())
            {
                SuccessRate -= 10;
            }

            return SuccessRate;
        }

        private int GetIfOverweight()
        {
            int SuccessRate = 0;
            if (_selectedUsers.SelectedBernt.GetOverweight())
            {
                SuccessRate -= 10;
            }

            return SuccessRate;
        }

        private int GetIfDiabetes()
        {
            int SuccessRate = 0;
            if (_selectedUsers.SelectedBernt.GetOverweight())
            {
                SuccessRate -= 10;
            }

            return SuccessRate;
        }
        private int GetIfAthletic()
        {
            int SuccessRate = 0;
            if (_selectedUsers.SelectedBernt.GetAthletic())
            {
                SuccessRate += 15;
            }

            return SuccessRate;
        }
    }
}
