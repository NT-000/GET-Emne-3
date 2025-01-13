namespace OrganTransplantNew;

public class Patient : UserParent
{
    public string BloodType { get;private set; }
    public bool IsSmoker { get;private set; }
    public bool IsFat { get;private set; }
    public bool IsDiabetic { get;private set; }
    public bool IsAthletic { get;private set; }

    public Patient(string firstName, string lastName, int age, Guid id, string gender, double successRate, string bloodType, bool isSmoker, bool isFat, bool isDiabetic, bool isAthletic) : base(firstName, lastName, age, id, gender, successRate)
    {
        
        BloodType = bloodType;
        IsSmoker = isSmoker;
        IsFat = isFat;
        IsDiabetic = isDiabetic;
        IsAthletic = isAthletic;
        Type = "Patient";
        
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Blood type:{BloodType}\nSmoker:{IsSmoker}\nOverweight:{IsFat}\nDiabetic:{IsDiabetic}\nAthletic:{IsAthletic}");
        Console.WriteLine($"{Line}");
    }
    
}