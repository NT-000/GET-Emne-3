using static System.Console;

namespace OrganTransplant
{
    internal class Program
    {   
       public static Persons bernt = new Persons("Bernt", "Berntsen", 31, "A-", false, false, false, true);
        private static List<Doctor> _doctors = GetDoctorsList();
        private static List<Persons> donors;


        static void Main(string[] args)
        {
            Console.WriteLine("\r\n#     \u2584\u2588    \u2588\u2584     \u2584\u2588\u2588\u2588\u2588\u2588\u2588\u2584     \u2584\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588    \u2584\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2584  \u2584\u2588      \u2588\u2588\u2588        \u2584\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588  \u2584\u2588       \r\n#    \u2588\u2588\u2588    \u2588\u2588\u2588   \u2588\u2588\u2588    \u2588\u2588\u2588   \u2588\u2588\u2588    \u2588\u2588\u2588   \u2588\u2588\u2588    \u2588\u2588\u2588 \u2588\u2588\u2588  \u2580\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2584   \u2588\u2588\u2588    \u2588\u2588\u2588 \u2588\u2588\u2588       \r\n#    \u2588\u2588\u2588    \u2588\u2588\u2588   \u2588\u2588\u2588    \u2588\u2588\u2588   \u2588\u2588\u2588    \u2588\u2580    \u2588\u2588\u2588    \u2588\u2588\u2588 \u2588\u2588\u2588\u258c    \u2580\u2588\u2588\u2588\u2580\u2580\u2588\u2588   \u2588\u2588\u2588    \u2588\u2588\u2588 \u2588\u2588\u2588       \r\n#   \u2584\u2588\u2588\u2588\u2584\u2584\u2584\u2584\u2588\u2588\u2588\u2584\u2584 \u2588\u2588\u2588    \u2588\u2588\u2588   \u2588\u2588\u2588          \u2588\u2588\u2588    \u2588\u2588\u2588 \u2588\u2588\u2588\u258c     \u2588\u2588\u2588   \u2580   \u2588\u2588\u2588    \u2588\u2588\u2588 \u2588\u2588\u2588       \r\n#  \u2580\u2580\u2588\u2588\u2588\u2580\u2580\u2580\u2580\u2588\u2588\u2588\u2580  \u2588\u2588\u2588    \u2588\u2588\u2588 \u2580\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588 \u2580\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2580  \u2588\u2588\u2588\u258c     \u2588\u2588\u2588     \u2580\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588 \u2588\u2588\u2588       \r\n#    \u2588\u2588\u2588    \u2588\u2588\u2588   \u2588\u2588\u2588    \u2588\u2588\u2588          \u2588\u2588\u2588   \u2588\u2588\u2588        \u2588\u2588\u2588      \u2588\u2588\u2588       \u2588\u2588\u2588    \u2588\u2588\u2588 \u2588\u2588\u2588       \r\n#    \u2588\u2588\u2588    \u2588\u2588\u2588   \u2588\u2588\u2588    \u2588\u2588\u2588    \u2584\u2588    \u2588\u2588\u2588   \u2588\u2588\u2588        \u2588\u2588\u2588      \u2588\u2588\u2588       \u2588\u2588\u2588    \u2588\u2588\u2588 \u2588\u2588\u2588\u258c    \u2584 \r\n#    \u2588\u2588\u2588    \u2588\u2580     \u2580\u2588\u2588\u2588\u2588\u2588\u2588\u2580   \u2584\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2580   \u2584\u2588\u2588\u2588\u2588\u2580      \u2588\u2580      \u2584\u2588\u2588\u2588\u2588\u2580     \u2588\u2588\u2588    \u2588\u2580  \u2588\u2588\u2588\u2588\u2588\u2584\u2584\u2588\u2588 \r\n#                                                                                    \u2580         \r\n");
            var random = new Random();
            donors = new Persons().RandomDonors(10, random);
            _doctors = new Doctor().RandomDoctors(5, random);

            var operationRoom = new OperationRoom(donors, _doctors, bernt);
            operationRoom.MenuOperation();


        }

        public static void GetInfo()
        {
            
            new Persons().CalculateIndividualDonorSuccess();
            WriteLine("\nDonor List\n");
            foreach (var patient in donors)
            {
                WriteLine("---------------------------------------------");
                WriteLine($"\nFirstname:{patient.GetFirstName()}");
                WriteLine($"Lastname: {patient.GetLastName()}");
                WriteLine($"Age: {patient.GetAge()}");
                WriteLine($"Bloodtype: {patient.GetBloodType()}");
                WriteLine($"Smoker: {patient.GetIsSmoker()}");
                WriteLine($"Overweight: {patient.GetIsFat()}");
                WriteLine($"Diabetes: {patient.GetIsDiabetes()}");
                WriteLine($"Athletic: {patient.GetIsAthletic()}");
                WriteLine($"Survival rate: {patient.GetDonorSuccessRatio()}%");
                WriteLine("---------------------------------------------");
            }
        }

        public void GetInfoDoctors()
        {
           Doctor doc = new Doctor();
            doc.CalculateIndividualDoctorSuccess();
            WriteLine("Doctor List:");
            foreach (var doctor in _doctors)
            {
                WriteLine("---------------------------------------------");
                WriteLine($"\nFirstname: {doctor.GetDoctorName()}");
                WriteLine($"Lastname: {doctor.GetDoctorLastName()}");
                WriteLine($"Age: {doctor.GetDoctorAge()}");
                WriteLine($"Experience: {doctor.GetDoctorLevel()}");
                WriteLine($"Drunk: {doctor.GetIsDrunkard()}");
                WriteLine($"Sloppy: {doctor.GetIsSloppy()}");
                WriteLine($"Sharp: {doctor.GetIsSharp()}\n");
                WriteLine($"Skill: {doctor.GetDoctorSuccessRatio()}%");
                WriteLine("---------------------------------------------");
            }

        }

        public List<Persons> GetDonorsList()
        {
            return donors;
        }
        public static List<Doctor> GetDoctorsList()
        {
            return _doctors;
        }

        public static Persons GetBernt()
        {
            return bernt;
        }




    }
}
