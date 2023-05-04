namespace PersonsInfo;

public class StartUp
{

    public static void Main()
    {
        Team team = new Team("SoftUni");
        List<Person> persons = new List<Person>();
        foreach (Person person in persons)
        {
            team.AddPlayer(person);
        }
    }

}