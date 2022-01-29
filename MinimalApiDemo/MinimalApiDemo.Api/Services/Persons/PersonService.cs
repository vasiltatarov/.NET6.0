namespace MinimalApiDemo.Api.Services.Persons;

public class PersonService : IPersonService
{
    public IEnumerable<Person> GetPersons()
    {
        var persons = new Person[]
        {
            new Person()
            {
                Name = "Svetlin",
                Age = 23,
                Profession = "Security",
            },
            new Person()
            {
                Name = "Donika",
                Age = 21,
                Profession = "Lawyer",
            },
            new Person()
            {
                Name = "Vasil",
                Age = 21,
                Profession = "Software Developer",
            }
        };

        return persons;
    }
}
