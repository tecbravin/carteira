using CarteiraApi.Models.Requests.Operation;
using CarteiraApi.Models.Responses;
using CarteiraApi.Models.Responses.Operation;
using System.Threading.Tasks;

namespace CarteiraApi.Interfaces.Services
{
    public interface IOperationService
    {
        Task<BaseResponse> Add(OperationAddRequest request);
        Task<OperationGetResponse> Get(OperationGetRequest request);
    }
}
