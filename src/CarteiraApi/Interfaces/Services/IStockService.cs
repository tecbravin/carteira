using CarteiraApi.Models.Requests.Stock;
using CarteiraApi.Models.Responses;
using System.Threading.Tasks;

namespace CarteiraApi.Interfaces.Services
{
    public interface IStockService
    {
        Task<BaseResponse> Add(StockAddRequest request);
        Task<BaseResponse> Update(StockUpdateRequest request);
    }
}
