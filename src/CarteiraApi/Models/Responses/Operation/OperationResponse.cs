using CarteiraApi.Models.Responses.Stock;
using System;

namespace CarteiraApi.Models.Responses.Operation
{
    public class OperationResponse
    {
        public StockResponse Stock { get; set; }
        public string Operation { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
