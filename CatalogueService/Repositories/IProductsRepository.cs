using System.Collections.Generic;
using CatalogueService.Repositories.Models;

namespace CatalogueService.Repositories
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetProducts();
    }
}