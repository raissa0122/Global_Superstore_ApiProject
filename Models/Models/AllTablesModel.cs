using CsvHelper.Configuration.Attributes;
using System;

namespace Models
{
    public class AllTablesModel
    {
        [Name(name: "Row ID")]
        public string RowID { get; set; }

        [Name(name: "Order ID")]
        public string OrderID { get; set; }

        [Name(name: "Order Date")]
        public string OrderDate { get; set; }

        [Name(name: "Ship Date")]
        public string ShipDate { get; set; }

        [Name(name: "Ship Mode")]
        public string ShipMode { get; set; }

        [Name(name: "Customer ID")]
        public string CustomerID { get; set; }

        [Name(name: "Customer Name")]
        public string CustomerName { get; set; }

        public string Segment { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [Name(name: "Postal Code")]
        public string PostalCode { get; set; }
        public string Market { get; set; }
        public string Region { get; set; }

        [Name(name: "Product ID")]
        public string ProductID { get; set; }
        public string Category { get; set; }

        [Name(name: "Sub-Category")]
        public string Sub_Category { get; set; }

        [Name(name: "Product Name")]
        public string ProductName { get; set; }
        public string Sales { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public string Profit { get; set; }

        [Name(name: "Shipping Cost")]
        public string ShippingCost { get; set; }

        [Name(name: "Order Priority")]
        public string OrderPriority { get; set; }
    }
}
