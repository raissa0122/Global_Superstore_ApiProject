using System.Collections.Generic;

namespace Models
{
    public class Continents
    {
        public int Id { get; set; }
        public string ContinentName { get; set; }

        public List<Countries> Countries { get; set; }

    }
}
