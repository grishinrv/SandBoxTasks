namespace Linq.Data;

public class DataSetFactory
{
    private static Random _random = new ();
    private static DateTime _minBirthDate = DateTime.Parse("01/01/1955");
    private static DateTime _maxBirthDate = DateTime.Parse("01/01/2003");
    private static TimeSpan _timeSpan = _maxBirthDate - _minBirthDate;
    private static Dictionary<int, string[]> _hierarchyTitles = new()
    {
        { 0, new[] { "CEO" } },
        { 1, new[] { "Head of department", "Manager", "Lead", "Officer" } },
        { 2, new[] { "Analyst", "Developer", "Engineer", "Specialist" } }
    };

    public static IList<Person> CreateDataSet()
    {
        var ceo = CreatePerson(0, null);
        List<Person> dataset = new List<Person>(30) { ceo };
        int departmentsQuantity = _random.Next(5, 10);
        for (int i = 0; i < departmentsQuantity -1; i++)
        {
            dataset.AddRange(CreateDepartment(ceo));
        }

        return dataset;
    }

    private static List<Person> CreateDepartment(Person boss)
    {
        int numberOfEmployees = _random.Next(3, 10);
        Person departmentManager = CreatePerson(1, boss);
        List<Person> employess = new List<Person>(numberOfEmployees) { departmentManager };
        for (int i = 1; i < numberOfEmployees - 1; i++)
        {
            employess.Add(CreatePerson(2, departmentManager));
        }

        return employess;
    }

    private static Person CreatePerson(int level, Person boss)
    {
        TimeSpan newSpan = new TimeSpan(0, _random.Next(0, (int)_timeSpan.TotalMinutes), 0);
        DateTime birthDate = _minBirthDate + newSpan;
        return new Person()
        {
            Id = Guid.NewGuid(),
            Boss = boss,
            BirthDate = birthDate,
            JobTitle = _hierarchyTitles[level][_random.Next(0, _hierarchyTitles[level].Length - 1)]
        };
    }
}