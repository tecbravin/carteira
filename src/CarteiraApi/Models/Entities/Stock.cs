using System.Diagnostics.CodeAnalysis;

namespace CarteiraApi.Models.Entities
{
    [ExcludeFromCodeCoverage]
    public class Stock
    {
        public int Id { get; set; }
        public string StockCode { get; set; }
        public string CompanyName { get; set; }
    }
}
