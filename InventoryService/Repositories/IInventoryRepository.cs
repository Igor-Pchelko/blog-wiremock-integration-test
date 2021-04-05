namespace InventoryService.Repositories
{
    public interface IInventoryRepository
    {
        void SetProductQuantity(string productId, int quantity);
        int GetProductQuantity(string productId);
    }
}