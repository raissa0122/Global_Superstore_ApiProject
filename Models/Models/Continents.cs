using System.Collections.Generic;

namespace Models
{
    public class Continents
    {
        public int Id { get; set; }
        public string ContinentsName { get; set; }

        public List<Countries> Countries { get; set; }

    }
}
