using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimpleProjectClassLibrary;
using SimpleProjectTDD;

[assembly: WebJobsStartup(typeof(Startup))]
namespace SimpleProjectTDD;

public class Startup : IWebJobsStartup
{
    public void Configure(IWebJobsBuilder builder)
    {
        builder.Services.AddTransient<IExampleService, ExampleService>();
    }
}
