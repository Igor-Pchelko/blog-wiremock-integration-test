using System.Threading.Tasks;
using CatalogueService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogueService.Controllers
{
    [ApiController]
    [Route("v1/catalogue/products")]
    public class ProductsCatalogueController : ControllerBase
    {
        private readonly ICatalogueProvider _catalogueProvider;

        public ProductsCatalogueController(ICatalogueProvider catalogueProvider)
        {
            _catalogueProvider = catalogueProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var catalogue = await _catalogueProvider.GetAllEntriesAsync();
            return Ok(catalogue);
        }
    }
}