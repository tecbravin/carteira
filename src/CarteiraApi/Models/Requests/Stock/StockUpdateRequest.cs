namespace CarteiraApi.Models.Requests.Stock
{
    public class StockUpdateRequest
    {
        public int Id { get; set; }
        public string StockCode { get; set; }
        public string CompanyName { get; set; }
    }
}
