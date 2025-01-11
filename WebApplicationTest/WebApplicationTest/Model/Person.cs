namespace WebApplicationTest;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BirthYear { get; set; }

    public Person(string firstName, string lastName, int birthYear)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthYear = birthYear;
    }
}