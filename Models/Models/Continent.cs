using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;

namespace Models
{
    public class Continent
    {
        public int Id { get; set; }

        [Name("Region")]
        public string ContinentName { get; set; }

        public List<Countries> Countries { get; set; }

    }
}
