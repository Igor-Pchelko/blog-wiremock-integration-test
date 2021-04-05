using System.Collections.Generic;

namespace InventoryService.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private Dictionary<string, int> _data = new();
        
        public void SetProductQuantity(string productId, int quantity)
        {
            _data[productId] = quantity;
        }

        public int GetProductQuantity(string productId)
        {
            return _data.TryGetValue(productId, out var currentQuantity) ? currentQuantity : 0;
        }
    }
}