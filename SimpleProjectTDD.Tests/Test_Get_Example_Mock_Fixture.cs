using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SimpleProjectClassLibrary;
using Xunit;

namespace SimpleProjectTDD.Tests;

public class Test_Get_Example_Mock_Fixture
    {
        protected Fixture _fixture = new Fixture();

        [Fact]
        public void TestsSuccessStatus200()
        {
            var request = UnitTestFactory.Request();
            var _exampleServiceMock = new Mock<IExampleService>();

            // Criando objeto de retorno com Fixture
            var resultado = _fixture.Build<PersonModel>().With(c => c.Age, 18).Create();

            // Mock do metodo GetPerson
            _exampleServiceMock.Setup(c => c.GetPerson(It.IsAny<bool>())).ReturnsAsync(resultado);

            var result = new Get_Example_Mock_Fixture(_exampleServiceMock.Object).Run(request, UnitTestFactory.Logger());
            var okResult = result.Result as OkObjectResult;

            Assert.Equal(200, okResult?.StatusCode);

            _exampleServiceMock.Verify(c => c.GetPerson(It.IsAny<bool>()), Times.Once());
        }
    }
