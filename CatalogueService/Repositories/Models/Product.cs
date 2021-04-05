namespace CatalogueService.Repositories.Models
{
    public record Product
    {
        public string ProductId { get; init; }
        public string Description { get; init; }
    }
}