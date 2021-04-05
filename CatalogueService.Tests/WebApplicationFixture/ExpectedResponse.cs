using WireMock.Server;

namespace CatalogueService.Tests.WebApplicationFixture
{
    public class ExpectedResponse
    {
        public WireMockServer Service { get; }
        public string Path { get; }
        public int ExpectedStatusCode { get; }

        public ExpectedResponse(WireMockServer service, string path, int expectedStatusCode)
        {
            Service = service;
            Path = path;
            ExpectedStatusCode = expectedStatusCode;
        }
    }
}