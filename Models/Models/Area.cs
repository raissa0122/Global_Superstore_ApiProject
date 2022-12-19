
using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;
using CsvHelper.Configuration;
using System;

namespace Models
{
    public class Area
    {
        public int Id { get; set; }

        [Name("City")]
        public string Sity { get; set; }

        [Name("State")]
        public string State { get; set; }

        [Name("PostalCode")]
        public string PostCode { get; set; }

        [Name("Market")]
        public string Market { get; set; } 

        public List<Customer> Customer { get; set; }

        public ICollection<Country> Countries { get; set; }
    }
}
