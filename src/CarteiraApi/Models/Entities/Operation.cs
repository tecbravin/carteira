using CarteiraApi.Models.Enums;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CarteiraApi.Models.Entities
{
    [ExcludeFromCodeCoverage]
    public class Operation
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public EOperationType Order { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
