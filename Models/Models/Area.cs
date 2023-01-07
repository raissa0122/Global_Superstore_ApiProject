
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

        public int? CustomerId { get; set; }
        public int? ContinentId { get; set; }
        public int? CountryId { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }




    }
}
