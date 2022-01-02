using CarteiraApi.Models.Requests.ExchangeRate;
using CarteiraApi.Models.Responses.ExchangeRate;
using System.Threading.Tasks;

namespace CarteiraApi.Interfaces.Services
{
    public interface IExchangeRateService
    {
        Task<ExchangeRateResponse> Get(ExchangeRateGetRequest request);
    }
}
