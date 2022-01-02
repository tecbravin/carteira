using System.Collections.Generic;

namespace CarteiraApi.Models.Responses.Operation
{
    public class OperationGetResponse : BaseResponse
    {
        public IEnumerable<OperationResponse> Operations { get; set; }
    }
}
