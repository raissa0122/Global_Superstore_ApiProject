
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICsvService
    {
        public List<Area> ReadAreasFromFile(string filename);
        public List<Continent> ReadContinentsFromFile(string filename);
        public List<Country> ReadCountriesFromFile(string filename);


    }
}
