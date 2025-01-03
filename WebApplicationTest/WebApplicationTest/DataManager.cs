namespace WebApplicationTest;

public class DataManager
{
    public static Person[] GetPeople()
    {
        return new Person[]
        {
            new Person("Jan", "London", 1980),
            new Person("Frode", "Johnsen", 1932),
        };
    }
}