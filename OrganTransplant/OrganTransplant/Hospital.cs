namespace OrganTransplant
{
    internal class Hospital
    {  private readonly Persons bernt = Program.GetBernt(); 
       private readonly List<Persons> _potentialDonors = Program.GetDonorsList();
       private int _operationSucces {get; set;}
       private List<Doctor> doctors = Program.GetDoctorsList();
       private static Doctor SelectedDoctor = SelectedDoctor.GetSelectedDoctor();
       private static Persons SelectedPerson = Persons.GetSelectedPerson();




        public string CheckBloodtype()
        {
            
            Console.WriteLine($"{bernt.GetFirstName()}");

            Console.WriteLine($"Checking blood type compatibility for:{bernt.GetLastName()}, {bernt.GetFirstName()} (Blood Type: {bernt.GetBloodType()})");
            string space = "------------------------------";
            var bloodMatches = _potentialDonors.Where(donor => donor.GetBloodType() == bernt.GetBloodType()).ToList();
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
            if (bernt.GetSmoker())
            {
                SuccessRate -= 10;
            }

            return SuccessRate;
        }

        private int GetIfOverweight()
        {
            int SuccessRate = 0;
            if (bernt.GetOverweight())
            {
                SuccessRate -= 10;
            }

            return SuccessRate;
        }

        private int GetIfDiabetes()
        {
            int SuccessRate = 0;
            if (bernt.GetOverweight())
            {
                SuccessRate -= 10;
            }

            return SuccessRate;
        }
        private int GetIfAthletic()
        {
            int SuccessRate = 0;
            if (bernt.GetAthletic())
            {
                SuccessRate += 15;
            }

            return SuccessRate;
        }
    }
}
