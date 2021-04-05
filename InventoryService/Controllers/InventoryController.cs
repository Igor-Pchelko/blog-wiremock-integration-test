using InventoryService.Controllers.Models;
using InventoryService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("v1/inventory")]
    public class InventoryController : ControllerBase
    {
        private IInventoryRepository _repository;

        public InventoryController(IInventoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{productId}")]
        public IActionResult GetInventory(string productId)
        {
            return Ok(new GetInventoryResponse
            {
                Quantity = _repository.GetProductQuantity(productId)
            });
        }
        
        [HttpPut]
        public IActionResult SetInventory([FromBody]SetInventoryRequest request)
        {
            _repository.SetProductQuantity(request.ProductId, request.Quantity);
            return NoContent();
        }
    }
}