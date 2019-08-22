using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wickers.DOTNET.Example.Models;
using Xunit;

namespace Wickers.DOTNET.Example.Tests.ExampleTests
{
    public class ExampleUnitTest : IClassFixture<ExampleFixture>
    {
        private ExampleFixture _fixture;

        public ExampleUnitTest(ExampleFixture Fixture)
        {
            _fixture = Fixture;
        }

        [Fact]
        public async Task Example_API_Select_With_Results()
        {
            //Assign - Empty Results
            List<ExampleModel> mockData = ExampleMockData.GetMockExampleData();
            _fixture.WireupFixture(mockData);

            //Call API
            var results = await _fixture.ApiController.GetData();

            //Assert
            var apiResult = results as OkObjectResult;
            Assert.NotNull(apiResult);
        }

        [Fact]
        public async Task Example_API_Select_ByKey_Results()
        {
            //Assign - Empty Results
            List<ExampleModel> mockData = ExampleMockData.GetMockExampleData();
            _fixture.WireupFixture(mockData);

            //Call API
            var results = await _fixture.ApiController.GetDataByID("21");

            //Assert
            var apiResult = results as OkObjectResult;
            Assert.NotNull(apiResult);
        }

        [Fact]
        public async Task Example_API_Select_ByKey_No_Content()
        {
            //Assign - Empty Results
            List<ExampleModel> mockData = ExampleMockData.GetMockExampleData();
            _fixture.WireupFixture(mockData);

            //Call API
            var results = await _fixture.ApiController.GetDataByID("100");

            //Assert
            var apiResult = results as NoContentResult;
            Assert.NotNull(apiResult);
        }
    }
}
