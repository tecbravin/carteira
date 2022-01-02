using System.Diagnostics.CodeAnalysis;

namespace CarteiraApi.Models.Entities
{
    [ExcludeFromCodeCoverage]
    public class StockParameter
    {
        public const int Fees = 1;
        public const int BrokerageCost = 2;

        public int Id { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
}
