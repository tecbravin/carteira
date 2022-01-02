using CarteiraApi.Models.Entities;
using System.Threading.Tasks;

namespace CarteiraApi.Interfaces.Repositories
{
    public interface IStockParameterRepository
    {
        Task<StockParameter> Get(int id);
    }
}
