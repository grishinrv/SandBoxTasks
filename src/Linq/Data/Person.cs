namespace Linq.Data;

public class Person
{
    public string JobTitle { get; init; }
    public Guid Id { get; init; }
    public DateTime BirthDate { get; init; }
    public Person Boss { get; init; }
}