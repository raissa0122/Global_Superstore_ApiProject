
using System.Collections.Generic;

namespace Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Sity { get; set; }
        public string State { get; set; }
        public int PostCode { get; set; }
        public string Market { get; set; }

        public List<Customer> Customer { get; set; }

        public ICollection<Countries> Countries { get; set; }
    }
}
