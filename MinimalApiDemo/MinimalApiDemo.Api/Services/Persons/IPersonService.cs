namespace MinimalApiDemo.Api.Services.Persons;

public interface IPersonService
{
    IEnumerable<Person> GetPersons();
}
