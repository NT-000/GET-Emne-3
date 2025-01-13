namespace OrganTransplantNew;

public class UserParent
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }
    public Guid Id { get; private set; }
    public string Gender { get; private set; }
    public double SuccessRate { get; private set; }
    public string Type { get; protected set; }
    public string Line = new string('_', 60);
    public static int Counter { get; set; } = 1;
    public int CountId {get; private set;}

    public UserParent(string firstName, string lastName, int age, Guid id, string gender, double successRate)
    {
        CountId = Counter++;
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Gender = gender;
        SuccessRate = successRate;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine(Type == "Patient" ? $"\nPatient number: {CountId} - JOURNAL -" : "\nDoctor info");
        Console.WriteLine($"{Line}");
        Console.WriteLine($"Firstname:{FirstName}\nLast name:{LastName}\nRole:{Type}\nId number:{Id}\nAge:{Age} years old.\nGender:{Gender}\nSUCCESS CHANCE:{SuccessRate}%");
    }

    public int GetCountId()
    {
        return CountId;
    }

    public int GetCounter()
    {
        return Counter;
    }

    public static void ResetCounter()
    {
       Counter = 1;
    }

    public Guid GetId()
    {
        return Id;
    }

    public double GetSuccessRate()
    {
        return SuccessRate;
    }

    public double SetSuccessRate(double successRate)
    {
       return SuccessRate = successRate;
    }
    
    
}