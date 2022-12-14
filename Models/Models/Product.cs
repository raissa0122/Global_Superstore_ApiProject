using System.Collections.Generic;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductID { get; set; }

        public List<Sales> Sales { get; set; }

    }
}
