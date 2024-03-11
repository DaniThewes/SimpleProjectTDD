using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using SimpleProjectClassLibrary;
using System.Threading.Tasks;

namespace SimpleProjectTDD;

public class Get_Example_Mock_Fixture
{
    private readonly IExampleService _exampleService;

    public Get_Example_Mock_Fixture(IExampleService exampleService)
    {
        _exampleService = exampleService;
    }

    [FunctionName("Get_Example_Mock_Fixture")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "example_mock_fixture")] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        var person = await _exampleService.GetPerson(true);

        string responseMessage = $"Hello. {person.Name} This HTTP triggered function executed successfully.";
        return new OkObjectResult(responseMessage);
    }

}
