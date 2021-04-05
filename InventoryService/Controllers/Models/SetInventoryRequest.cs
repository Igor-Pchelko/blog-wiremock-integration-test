namespace InventoryService.Controllers.Models
{
    public record SetInventoryRequest
    {
        public string ProductId { get; init; }
        public int Quantity { get; init; }
    }
}