using System.Diagnostics.CodeAnalysis;

namespace CarteiraApi.Models.Responses.ExchangeRate
{
    [ExcludeFromCodeCoverage]
    public class ExchangeRateServiceGetResponse
    {
        public ExchangeRateServiceGetResultResponse QuoteResponse { get; set; }
    }
}
