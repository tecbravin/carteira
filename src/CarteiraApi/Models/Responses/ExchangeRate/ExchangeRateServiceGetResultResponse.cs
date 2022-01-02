using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CarteiraApi.Models.Responses.ExchangeRate
{
    [ExcludeFromCodeCoverage]
    public class ExchangeRateServiceGetResultResponse
    {
        public IEnumerable<ExchangeRateServiceGetResultItemResponse> Result { get; set; }
    }
}
