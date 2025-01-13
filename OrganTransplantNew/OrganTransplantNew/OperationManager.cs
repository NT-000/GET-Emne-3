using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace OrganTransplantNew;

public class OperationManager
{
    public List<Patient> BloodMatches  = [];
    Random random = new Random();
    public OperationManager(){}
    
    public void FindBloodMatches(UserManager userManager, SelectedUser selectedUser)
    {
        BloodMatches.Clear();
        var selectedPatient = selectedUser.GetPatient1();
       
        if (selectedPatient == null)
        {
            Console.WriteLine("Select patient 1 first...");
            return;
        }
        Console.WriteLine($"POTENTIAL DONORS FOR {selectedPatient.BloodType}\n");
        foreach (var user in userManager.Users)
        {
            if (user is not Patient patient) continue;
            if(patient.GetId() == selectedPatient.GetId()) continue;
            if (!BloodMatches.Contains(user) && IsCompatible(selectedPatient.BloodType, patient.BloodType))
            {
                BloodMatches.Add(patient);
            }
        }

        Console.WriteLine($"{BloodMatches.Count} blood matches");
    }

    public bool IsCompatible(string recipientBloodType, string donorBloodType)
    {
        if (recipientBloodType == "A+")
            return donorBloodType == "A+" || donorBloodType == "A-" || donorBloodType == "O+" || donorBloodType == "O-";
        if (recipientBloodType == "A-")
            return donorBloodType == "A-" || donorBloodType == "O-";
        if (recipientBloodType == "B+")
            return donorBloodType == "B+" || donorBloodType == "B-" || donorBloodType == "O+" || donorBloodType == "O-";
        if (recipientBloodType == "B-")
            return donorBloodType == "B-" || donorBloodType == "O-";
        if (recipientBloodType == "O+")
            return donorBloodType == "O+" || donorBloodType == "O-";
        if (recipientBloodType == "O-")
            return donorBloodType == "O-";
        return false;
    }

    public void ShowPotentialMatches(UserManager userManager, SelectedUser selectedUser, OperationManager opManager)
    {
        FindBloodMatches(userManager, selectedUser);
        var filteredMatches = BloodMatches.Where(patient => patient.GetId() != selectedUser.GetPatient1().GetId()).ToList();
        var sortedList = filteredMatches.OrderBy(p => p.SuccessRate).ToList();
        foreach (var patient in sortedList)
        {
                patient.ShowInfo();
        }

    }

    public void DoOperation(SelectedUser selectedUser)
    {
        var patient1 = GetAllSelectedUsers(selectedUser, out var patient2, out var doctor);
        var chanceSuccess = CalculateOperationSuccess(patient1,patient2, doctor);
        chanceSuccess = Math.Clamp(chanceSuccess, 0, 100);
        OperationInfo(patient1, patient2, doctor, chanceSuccess);
        Console.WriteLine("Are you sure you want to proceed? (y/n)");
        int randomNumber = random.Next(0, 100);
        var answer = Console.ReadLine().ToLower();
        if (answer is "y" or "yes")
        {
            if (randomNumber <= chanceSuccess)
            {
                Console.WriteLine("OPERATION WAS A SUCCESS!");
                Console.WriteLine($"{patient1.FirstName} and {patient2.FirstName} both survives.");
            }
            else
            {
                Console.WriteLine($"OPERATION FAILED, BOTH PATIENTS DIED!\n{doctor.Type} {doctor.LastName} was fired");
            }
        }
    }

    private void OperationInfo(Patient patient1, Patient patient2, Doctor doctor, double chanceSuccess)
    {
        Console.WriteLine($"Patient 1 ID:{patient1.Id} - Patient 2 ID:{patient2.Id}\nBlood type:{patient1.BloodType}{patient2.BloodType}");
        Console.WriteLine($"Surgeon:{doctor.FirstName} {doctor.LastName} with {doctor.Experience} years of experience.");
        Console.WriteLine($"Total chance for success: {chanceSuccess}%");
    }

    private Patient GetAllSelectedUsers(SelectedUser selectedUser, out Patient patient2, out Doctor doctor)
    {
        var patient1 = selectedUser.GetPatient1();
        patient2 = selectedUser.GetPatient2();
        doctor = selectedUser.GetSelectedDoctor();
        return patient1;
    }

    public double CalculateOperationSuccess(Patient patient1, Patient patient2, Doctor doctor)
    {
        var successRate = patient1.GetSuccessRate();
        var chance = successRate + patient2.GetSuccessRate() + doctor.GetSuccessRate();
        return chance;
    }
    public List<Patient> GetBloodMatches()
    {
        return BloodMatches;
    }
    
}