using System;

namespace Models
{
    public class AllTablesModel
    {
        public string RowID { get; set; }
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string ShipMode { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Segment { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Market { get; set; }
        public string Region { get; set; }
        public string ProductID { get; set; }
        public string Category { get; set; }
        public string Sub_Category { get; set; }
        public string ProductName { get; set; }
        public string Sales { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public string Profit { get; set; }
        public string ShippingCost { get; set; }
        public string OrderPriority { get; set; }
    }
}
