using System.Collections.Generic;

namespace CarteiraApi.Models.Responses.Stock
{
    public class StockGetResponse : BaseResponse
    {
        public IEnumerable<StockResponse> Stocks { get; set; }
    }
}
