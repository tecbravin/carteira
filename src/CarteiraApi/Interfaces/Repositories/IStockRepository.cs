using CarteiraApi.Models.Entities;
using CarteiraApi.Models.Requests.Stock;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarteiraApi.Interfaces.Repositories
{
    public interface IStockRepository
    {
        Task<int> Add(StockAddRequest request);
        Task<IEnumerable<Stock>> Search(StockGetRequest request = null);
        Task<bool> Exists(StockGetRequest request);
        Task Update(StockUpdateRequest request);
    }
}
