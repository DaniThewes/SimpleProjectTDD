using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SimpleProjectTDD.Tests;

public class UnitTestFactory
{
    public static HttpRequest Request() {
        var req = new DefaultHttpContext().Request;
        req.Headers.Add("Content-Type", "application/json");
        req.Headers.Add("Accept", "application/json");

        return req;
    }

    public static ILogger Logger() {
        return new LoggerFactory().CreateLogger("Test");
    }
}
