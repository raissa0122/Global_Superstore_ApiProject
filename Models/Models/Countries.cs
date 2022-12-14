namespace Models
{
    public class Countries
    {
        public int Id { get; set; }
        public string CountryName { get; set; }


        public Continents Continents { get; set; }


        public Area Area { get; set; }
    }
}
