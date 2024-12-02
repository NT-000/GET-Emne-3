namespace OrganTransplant
{
    internal class Doctor
    {
        private List<Doctor> doctors = Program.GetDoctorsList();
        private static Doctor SelectedDoctor { get; set; }

        private string FirstName { get; set; }
        private string LastName { get; set; }
        private int Age { get; set; }

        private int Experience { get; set; }

        private bool IsDrunkard { get; set; }
        private bool IsSloppy { get; set; }
        private bool IsSharp { get; set; }

        private int SuccessRatio { get; set; }

        public Doctor()
        {

        }
        public Doctor(string firstName, string lastName, int age, int experience, bool isDrunkard, bool isSloppy, bool isSharp)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Experience = experience;
            IsDrunkard = isDrunkard;
            IsSloppy = isSloppy;
            IsSharp = isSharp;
            SuccessRatio = 0;
        }

        public Doctor GetSelectedDoctor()
        {
            return SelectedDoctor;
        }
        public void ChooseSelectedDoctor()
        {
            Console.WriteLine("Select your doctor");
            for (int i = 0; i < doctors.Count; i++)
            {
                Console.WriteLine($"{i}.{doctors[i].LastName}, {doctors[i].SuccessRatio}");
            }
            Console.WriteLine($"{doctors.Count + 1}. Exit");
            var inputSwitch = int.Parse(Console.ReadLine());
            SelectedDoctor = doctors[inputSwitch];
            var test = SelectedDoctor;
            Console.WriteLine($"You chose Doctor: {SelectedDoctor.FirstName}, {SelectedDoctor.LastName}\nSkill: {SelectedDoctor.SuccessRatio}");
        }

        public List<Doctor> RandomDoctors(int num, Random random)
        {
            List<Doctor> doctors = [];

            string[] firstNames = ["Arne", "Rolf", "Anton", "Kjell", "Heidi"];
            string[] lastNames = ["Jansen", "Edvartsen", "Hagen", "Olavesen", "Reier"];
            int[] levels = [1, 2, 3, 4, 5];


            for (int i = 0; i < num; i++)
            {
                string firstName = firstNames[random.Next(firstNames.Length)];
                string lastName = lastNames[random.Next(lastNames.Length)];
                int age = random.Next(25, 67);
                int level = levels[random.Next(levels.Length)];
                IsDrunkard = GetRandomBool(random);
                IsSloppy = GetRandomBool(random);
                IsSharp = GetRandomBool(random);

                if (IsSloppy == IsSharp)
                {
                    IsSloppy = !IsSharp;
                }

                doctors.Add(new Doctor(firstName, lastName, age, level, IsDrunkard, IsSloppy, IsSharp));

            }
            return doctors;
        }
        public bool GetRandomBool(Random random)
        {
            return random.Next(0, 2) == 1;
        }
        public string GetDoctorName()
        {
            return FirstName;
        }
        public string GetDoctorLastName()
        {
            return LastName;
        }

        public int GetDoctorAge()
        {
            return Age;
        }

        public int GetDoctorLevel()
        {
            return Experience;
        }

        public bool GetIsDrunkard()
        {
            return IsDrunkard;
        }

        public bool GetIsSloppy()
        {
            return IsSloppy;
        }

        public bool GetIsSharp()
        {
            return IsSharp;
        }

        private int GetDoctorSuccessAgeRate()
        {
            if (Age < 35) return 20;
            if (Age < 45) return 25;
            if (Age < 55) return 25;
            if (Age < 65) return 15;
            return -5;
        }

        private int GetDoctorIfSloppy()
        {
        return IsSloppy ? -15 : 0;
        }

        private int GetDoctorIfSharp()
        {
            return IsSharp ? 15 : 0;
        }
        private int GetDoctorIfDrunkard()
        {

            return IsDrunkard ? -20 : 0;
        }
        public void CalculateIndividualDoctorSuccess()
        {
            var doctorList = Program.GetDoctorsList();
            if (doctorList.Count == 0)
            {
                Console.WriteLine("No doctors found.");
                return;
            }
            foreach (var doctor in doctorList){
            doctor.SuccessRatio += GetDoctorSuccessAgeRate();
            doctor.SuccessRatio += GetDoctorIfSharp();
            doctor.SuccessRatio += GetDoctorIfSloppy();
            doctor.SuccessRatio += GetDoctorIfDrunkard();
            doctor.SuccessRatio += doctor.Experience * 5;
            doctor.SuccessRatio = Math.Clamp(doctor.SuccessRatio, 0, 100);
            }
        }

        public int GetDoctorSuccessRatio()
        {
            return SuccessRatio;
        }


    }
}
