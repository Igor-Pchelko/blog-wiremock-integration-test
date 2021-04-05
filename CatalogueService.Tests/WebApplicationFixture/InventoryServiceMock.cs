using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace CatalogueService.Tests.WebApplicationFixture
{
    public class InventoryServiceMock : WireMockServer
    {
        protected InventoryServiceMock(IWireMockServerSettings settings) : base(settings)
        {
        }
        
        public static InventoryServiceMock Start(int? port = 0, bool ssl = false)
        {
            return new (new WireMockServerSettings
            {
                Port = port,
                UseSSL = ssl
            });
        }
        
        public ExpectedResponse Response_to_GetInventory(string productId, int quantity)
        {
            var path = $"/v1/inventory/{productId}";
            
            Given(Request.Create().UsingGet()
                    .WithPath(path)
                )
                .RespondWith(Response.Create()
                    .WithBodyAsJson(new { Quantity = quantity })
                    .WithStatusCode(200));

            return new ExpectedResponse(this, path, 200);
        }
    }
}