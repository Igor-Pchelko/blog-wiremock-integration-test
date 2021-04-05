using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace CatalogueService.Tests.WebApplicationFixture
{
    public class WebApplicationTest : WebApplicationFactory<Startup>
    {
        public ITestOutputHelper? TestOutputHelper { get; set; }
        public InventoryServiceMock? InventoryServiceMock { get; private set; }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            InventoryServiceMock = InventoryServiceMock.Start();

            builder.ConfigureLogging((_, logging) =>
            {
                logging.ClearProviders();
                logging.AddXUnit(TestOutputHelper);
            });

            builder.ConfigureAppConfiguration((_, configurationBuilder) => 
                ConfigureBuilder(configurationBuilder));
 
            var host = builder.Build();
            host.Start();
            return host;
        }
        
        private void ConfigureBuilder(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "Settings:InventoryServiceUrl", $"{InventoryServiceMock.Urls.First()}" },
                });
        }
    }
}