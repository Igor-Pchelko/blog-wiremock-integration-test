namespace CatalogueService.Configuration
{
    public record Settings
    {
        public const string Name = "Settings";
        public string InventoryServiceUrl { get; init; }
    }
}