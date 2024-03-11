namespace SimpleProjectClassLibrary;

public class ExampleService : IExampleService
{

    public async Task<PersonModel> GetPerson(bool value)
    {
        return new PersonModel { Name = "Teste Name", Age = 18, Id = Guid.NewGuid() };
    }
}