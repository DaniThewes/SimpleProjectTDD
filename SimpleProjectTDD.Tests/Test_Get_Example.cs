using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Xunit;

namespace SimpleProjectTDD.Tests;

public class Test_Get_Example
{
    [Fact]
    public void TestsSuccessStatus200()
    {
        var request = UnitTestFactory.Request();
        request.Query = new QueryCollection(new Dictionary<string, StringValues> { { "name", "Daniel" } });

        var result = Get_Example.Run(request, UnitTestFactory.Logger());
        var okResult = result.Result as OkObjectResult;

        Assert.Equal(200, okResult?.StatusCode);
        Assert.Equal("Hello, Rian. This HTTP triggered function executed successfully.", okResult?.Value.ToString());

    }

    [Fact]
    public void TestsBadRequestStatus400()
    {
        var request = UnitTestFactory.Request();
        var result = Get_Example.Run(request, UnitTestFactory.Logger());
        var badRequestResult = result.Result as BadRequestObjectResult;

        Assert.Equal(400, badRequestResult?.StatusCode);
        Assert.Equal("Please pass a name on the query string", badRequestResult?.Value.ToString());
    }

    [Fact]
    public void TestsBadRequestNameStartWithAStatus400()
    {
        var request = UnitTestFactory.Request();
        request.Query = new QueryCollection(new Dictionary<string, StringValues> { { "name", "adalto" } });
        var result = Get_Example.Run(request, UnitTestFactory.Logger());
        var badRequestResult = result.Result as BadRequestObjectResult;

        Assert.Equal(400, badRequestResult?.StatusCode);
        Assert.Equal("Name cannot start with 'a'", badRequestResult?.Value.ToString());
    }
}