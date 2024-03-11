namespace SimpleProjectClassLibrary;

public interface IExampleService
{
    Task<PersonModel> GetPerson(bool value);
}