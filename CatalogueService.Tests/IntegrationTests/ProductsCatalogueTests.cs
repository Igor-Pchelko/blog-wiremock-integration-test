using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using CatalogueService.Services.Models;
using CatalogueService.Tests.WebApplicationFixture;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CatalogueService.Tests.IntegrationTests
{
    [Collection(nameof(WebApplicationTestCollection))]
    public class ProductsCatalogueTests
    {
        private readonly WebApplicationTest _factory;

        public ProductsCatalogueTests(ITestOutputHelper testOutputHelper, WebApplicationTest factory)
        {
            _factory = factory;
            _factory.TestOutputHelper = testOutputHelper;
        }

        [Fact]
        private async Task ShouldReturnExpectedResult()
        {
            // Arrange
            var client = _factory.CreateClient();
            var getYellowWingsInventory = _factory.InventoryServiceMock.Response_to_GetInventory("yellow-wings", 10);
            var getBlueWingsInventory = _factory.InventoryServiceMock.Response_to_GetInventory("blue-wings", 20);
            var getWhiteWingsInventory = _factory.InventoryServiceMock.Response_to_GetInventory("white-wings", 30);

            // Act
            var response = await client.GetAsync("v1/catalogue/products");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var resultCatalogue = await response.Content.ReadFromJsonAsync<IEnumerable<CatalogueEntry>>();

            _factory.TestOutputHelper.WriteLine(JsonSerializer.Serialize(resultCatalogue));

            var expectedCatalogue = new CatalogueEntry[]
            {
                new()
                {
                    ProductId = "yellow-wings",
                    Description = "Yellow wings",
                    Quantity = 10
                },
                new()
                {
                    ProductId = "blue-wings",
                    Description = "Blue wings",
                    Quantity = 20
                },
                new()
                {
                    ProductId = "white-wings",
                    Description = "White wings",
                    Quantity = 30
                },
            };

            resultCatalogue.Should().BeEquivalentTo(expectedCatalogue);
            getYellowWingsInventory.ShouldBeCompleted();
            getBlueWingsInventory.ShouldBeCompleted();
            getWhiteWingsInventory.ShouldBeCompleted();
        }
    }
}