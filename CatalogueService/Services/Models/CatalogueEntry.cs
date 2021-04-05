namespace CatalogueService.Services.Models
{
    public record CatalogueEntry
    {
        public string ProductId { get; init; }
        public string Description { get; init; }
        public int Quantity { get; init; }
    }
}
