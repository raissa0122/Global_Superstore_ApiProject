using CsvHelper.Configuration.Attributes;

namespace Models
{
    public class Country
    {
        public int Id { get; set; }

        [Name("Country")]
        public string CountryName { get; set; }


        public Continent Continents { get; set; }


      //  public Area Area { get; set; }
    }
}
