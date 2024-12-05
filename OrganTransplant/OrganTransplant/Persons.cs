namespace OrganTransplant
{   
    internal class Persons
    {
        private SelectedUsers _selectedUsers;
        private List<Persons> matchedList;

        
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private int Age { get; set; }
        private string BloodType { get; set; }
        private bool IsSmoker { get; set; }
        private bool IsFat { get; set; }
        private bool IsDiabetes { get; set; }
        private bool IsAthletic { get; set; }

        private int SuccessRatio { get; set; }

        public Persons ()
        {

        }
        public Persons(string firstName, string lastName, int age, string bloodType, bool isSmoker, bool isFat,
            bool isDiabetes, bool isAthletic)
        {

            FirstName = firstName;
            LastName = lastName;
            Age = age;
            BloodType = bloodType;
            IsSmoker = isSmoker;
            IsFat = isFat;
            IsDiabetes = isDiabetes;
            IsAthletic = isAthletic;
            SuccessRatio = 50;
        }

        public List<Persons> RandomDonors(int num, Random random)
        {
            List<Persons> potentialDonors = [];
            string[] firstNames =
            [
                "Nico", "Chris", "Jerry", "Anna", "Bibbi", "Svein", "Stein Are", "El Roger", "Bendik Romeo",
                "Fartstripa"
            ];
            string[] lastNames =
                ["Thue", "Jacobsen", "Hansen", "Svensen", "Thu", "Eriksen", "Amundsen", "Knott", "Knutsen", "Felgen"];
            string[] bloodTypes = ["A+", "A-", "B+", "B-", "O+"];

            for (int i = 0; i < num; i++)
            {
                string firstName = firstNames[random.Next(firstNames.Length)];
                string lastName = lastNames[random.Next(lastNames.Length)];
                string bloodType = bloodTypes[random.Next(bloodTypes.Length)];
                int age = random.Next(16, 91);
                bool isSmoker = GetRandomBool(random);
                bool isFat = GetRandomBool(random);
                bool isDiabetes = GetRandomBool(random);
                bool isAthletic = GetRandomBool(random);
                int successRate = 10;
                if (isAthletic == isFat)
                {
                    isAthletic = !isFat;
                }
                potentialDonors.Add(new Persons(firstName, lastName, age, bloodType, isSmoker, isFat, isDiabetes, isAthletic));
            }

            return potentialDonors;
        }


        public int GetSuccessRatioBernt()
        {
            var bernt = Program.bernt;
            return bernt.SuccessRatio;
        }
        public bool GetRandomBool(Random random)
        {
            return random.Next(0, 2) == 1;
        }

        public string GetFirstName()
        {
            return FirstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public int GetAge()
        {
            return Age;
        }

        public string GetBloodType()
        {
            return BloodType;
        }

        public string GetIsSmoker()
        {
            if (IsSmoker)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        public bool GetSmoker()
        {
            return IsSmoker;
        }
        public string GetIsFat()
        {
            if (IsFat)
            {
                return "Yes";
            }

            return "No";
        }

        public bool GetOverweight()
        {
            return IsFat;
        }
        public string GetIsDiabetes()
        {
            if (IsDiabetes)
            {
                return "Yes";
            }

            return "No";
        }

        public bool GetDiabetes()
        {
            return IsDiabetes;
        }

        public string GetIsAthletic()
        {
            if (IsAthletic)
            {
                return "Yes";
            }

            return "No";
        }

        public bool GetAthletic()
        {
            return IsAthletic;
        }
        public void CalculateIndividualDonorSuccess()
        {
            Program list = new Program();
            var donorList = list.GetDonorsList();

            if (donorList.Count == 0)
            {
                Console.WriteLine("No donors found.");
                return;
            }

            foreach (var donor in donorList)
            {
                donor.SuccessRatio +=donor.GetDonorSuccessAgeRate();
                donor.SuccessRatio +=donor.GetDonorIfDiabetes();
                donor.SuccessRatio +=donor.GetDonorIfFat();
                donor.SuccessRatio +=donor.GetDonorIfSmoker();
                donor.SuccessRatio = Math.Clamp(donor.SuccessRatio,0,100);
            }
            

        }
        private int GetDonorSuccessAgeRate()
        {
            if (Age < 35) return 30;
            if (Age < 45) return 15;
            if (Age < 55) return 5;
            if (Age < 65) return -20;
            return -20;
        }

        public int GetDonorAge()
        {
            return Age;
        }

        private int GetDonorIfDiabetes()
        {

            return IsDiabetes ? -15 : 0;
        }

        private int GetDonorIfFat()
        {
            return IsFat ? -15 : 0;
        }

        private int GetDonorIfSmoker()
        {
            return IsSmoker ? -15 : 0;
        }

        private string GetBerntAthlete(Persons selectedPerson)
        {
            return selectedPerson.GetAthletic()
                ? $"{selectedPerson.GetFirstName()} is in very good shape!"
                : $"{selectedPerson.GetFirstName()} is in bad shape...";
        }
        public int GetDonorSuccessRatio()
        {
            return SuccessRatio;

        }

        public void GetInfoSelectedPerson()
        {   
            var selectedBernt = Program.GetBernt();
            Console.WriteLine($"Journal: {selectedBernt.GetLastName()}, {selectedBernt.GetFirstName(),-15} ");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Age: {selectedBernt.GetAge()}");
            Console.WriteLine($"Fat: {selectedBernt.GetIsFat()}");
            Console.WriteLine($"Physical shape: {selectedBernt.GetBerntAthlete(selectedBernt)}");
            Console.WriteLine($"Diabetes: {selectedBernt.GetIsDiabetes()}");
            Console.WriteLine($"Smoker: {selectedBernt.GetIsSmoker()}");
            Console.WriteLine($"Blood Type:{selectedBernt.GetBloodType()}");
            Console.WriteLine($"Readiness for surgery: {selectedBernt.GetDonorSuccessRatio()}%");

        }


        public List<Persons> GetBloodMatches(Persons bernt, List<Persons> donors)
        {
            if (bernt == null)
                Console.WriteLine("bernt cannot be null.");
            ;
            if (donors == null)
                Console.WriteLine("Donors list cannot be null.");
            

            return donors.Where(donor => donor.GetBloodType() == bernt.GetBloodType()).ToList();
        }

        // selectedPerson

        public List<Persons> GetMatchedList()
        {
            return matchedList;
        }

    }

}

