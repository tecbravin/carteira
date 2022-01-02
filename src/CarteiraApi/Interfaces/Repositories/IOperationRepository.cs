using CarteiraApi.Models.Entities;
using CarteiraApi.Models.Requests.Operation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarteiraApi.Interfaces.Repositories
{
    public interface IOperationRepository
    {
        Task<int> Add(OperationAddRequest request);
        Task<IEnumerable<Operation>> Get(OperationGetRequest request);
    }
}
