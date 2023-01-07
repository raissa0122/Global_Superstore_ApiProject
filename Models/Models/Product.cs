using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        [Name(name: "Sub-Category")]
        public string SubCategory { get; set; }
        public string ProductID { get; set; }

       // public List<Order> Orders { get; set; }

    }
}
