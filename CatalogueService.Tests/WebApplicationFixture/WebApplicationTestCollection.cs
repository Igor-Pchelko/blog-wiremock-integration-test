using Xunit;

namespace CatalogueService.Tests.WebApplicationFixture
{
    [CollectionDefinition(nameof(WebApplicationTestCollection))]
    public class WebApplicationTestCollection : ICollectionFixture<WebApplicationTest>
    {
    }
}