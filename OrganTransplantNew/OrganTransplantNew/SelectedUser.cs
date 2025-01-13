namespace OrganTransplantNew;

public class SelectedUser
{
    public Doctor Doctor{get;private set;}
    public Patient Patient1{get;private set;}
    
    public Patient Patient2{get;private set;}

    public SelectedUser()
    {
        Doctor = null;
        Patient1 = null;
        Patient2 = null;
    }
    public Doctor GetSelectedDoctor()
    {
       return Doctor;
    }

    public Doctor SetDoctor(Doctor doctor)
    {
      return Doctor = doctor;
    }

    public Patient GetPatient1()
    {
        return Patient1;
    }

    public void SetPatient1(Patient patient)
    {
        if (Patient1 == null || Patient1.GetId() == patient.GetId())
        {
            Patient1 = patient;
        }
        else
        {
            Console.WriteLine("Patient 1 is already selected");
        }
    }

    public Patient GetPatient2()
    {
        return Patient2;
    }

    public void SetPatient2(Patient patient)
    {
        if (Patient2 == null || Patient2.GetId() == patient.GetId())
        {
            Patient2 = patient;
        }
        else
        {
            Console.WriteLine("Patient 2 is already selected");
        }
    }

    public string GetSelectedPatientBloodType()
    {
        return Patient1.BloodType;
    }
    
}