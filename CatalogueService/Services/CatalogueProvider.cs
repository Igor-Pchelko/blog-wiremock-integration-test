using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CatalogueService.Configuration;
using CatalogueService.Repositories;
using CatalogueService.Repositories.Models;
using CatalogueService.Services.Models;
using Microsoft.Extensions.Options;

namespace CatalogueService.Services
{
    public class CatalogueProvider : ICatalogueProvider
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Settings _settings;

        public CatalogueProvider(IProductsRepository productsRepository, IHttpClientFactory httpClientFactory, IOptions<Settings> settings)
        {
            _productsRepository = productsRepository;
            _httpClientFactory = httpClientFactory;
            _settings = settings.Value;
        }

        public async Task<IEnumerable<CatalogueEntry>> GetAllEntriesAsync()
        {
            var products = _productsRepository.GetProducts();
            var httpClient = _httpClientFactory.CreateClient();
            var tasks = products.Select(product => GetCatalogueEntryAsync(_settings.InventoryServiceUrl, product, httpClient));

            return await Task.WhenAll(tasks);
        }

        private static async Task<CatalogueEntry> GetCatalogueEntryAsync(string inventoryServiceUrl, Product product, HttpClient httpClient)
        {
            var url = $"{inventoryServiceUrl}/v1/inventory/{product.ProductId}";
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var inventory = await response.Content.ReadFromJsonAsync<GetInventoryResponse>();

            return new CatalogueEntry
            {
                ProductId = product.ProductId,
                Description = product.Description,
                Quantity = inventory.Quantity
            };
        }
    }
}