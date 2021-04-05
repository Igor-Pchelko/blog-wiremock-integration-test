using System.Collections.Generic;
using CatalogueService.Repositories.Models;

namespace CatalogueService.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly Product[] _products = 
        {
            new()
            {
                ProductId = "yellow-wings",
                Description = "Yellow wings"
            },
            new()
            {
                ProductId = "blue-wings",
                Description = "Blue wings"
            },
            new()
            {
                ProductId = "white-wings",
                Description = "White wings"
            }
        };
        
        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
    }
}