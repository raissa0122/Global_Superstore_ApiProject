using CsvHelper.Configuration.Attributes;
using System;

namespace Models
{
    public class Order
    {
        public int Id { get; set; }

        [Name(name: "Sales")]
        public string SalesCount { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public string Profit { get; set; }
        public string ShippingCost {  get; set; }
        public string OrderPriority { get; set; }
        public string OrderID { get; set; }
        public string OrderDate { get; set; }
        public string ShipDate { get; set; }
        public string ShipMode { get; set; }

       // Customer Customer { get; set; }

       // Product Product { get; set; }
    }
}
