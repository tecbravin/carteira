using CarteiraApi.Models.Enums;
using System;
using System.Text.Json.Serialization;

namespace CarteiraApi.Models.Requests.Operation
{
    public class OperationAddRequest
    {
        public string StockCode { get; set; }
        public EOperationType? Operation { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public int StockId { get; set; }

        [JsonIgnore]
        public DateTime Date { get; set; }

        [JsonIgnore]
        public decimal TotalAmount { get; set; }
    }
}
