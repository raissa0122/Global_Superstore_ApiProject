using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class SalesVM
    {
        public string SalesCount { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public string Profit { get; set; }
        public string ShippingCost { get; set; }
        public string OrderPriority { get; set; }
        public string OrderID { get; set; }
        public string OrderDate { get; set; }
        public string ShipDate { get; set; }
        public string ShipMode { get; set; }
    }
}
