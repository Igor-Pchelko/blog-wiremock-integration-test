using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogueService.Services.Models;

namespace CatalogueService.Services
{
    public interface ICatalogueProvider
    {
        Task<IEnumerable<CatalogueEntry>> GetAllEntriesAsync();
    }
}