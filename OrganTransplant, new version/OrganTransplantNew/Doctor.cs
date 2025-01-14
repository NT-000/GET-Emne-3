namespace OrganTransplantNew;

public class Doctor : UserParent
{
    public int Experience { get;private set; }
    public bool IsDrunk { get;private set; }
    public bool IsSloppy { get;private set; }
    public bool IsSharp {get;private set; }

    public Doctor(string firstName, string lastName, int age, Guid id, string gender, double successRate, int experience, bool isDrunk, bool isSloppy, bool isSharp) : base(firstName, lastName, age, id, gender, successRate)
    {
        Experience = experience;
        IsDrunk = isDrunk;
        IsSloppy = isSloppy;
        IsSharp = isSharp;
        Type = "Doctor";
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Years of experience: {Experience}\nAlcoholic:{IsDrunk}\nSloppy:{IsSloppy}\nSharp:{IsSharp}");
        Console.WriteLine($"{Line}");
    }
    
}