using Data;
using Models;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesForModels
{
    public class ContinentService
    {
        private AppDbContext _context;
        public ContinentService (AppDbContext context)
        {

            _context = context;
        }


        public void AddContinent (Continent continent)
        {
            var _continent = new Continent()
            {
                ContinentName = continent.ContinentName
            };
            _context.Continents.Add(_continent);
            _context.SaveChanges();
        }

        //GetAll
        public List<Continent> GetAllContinents() => _context.Continents.ToList();

        //GetById
        public Continent GetContinentsById(int continentId) => _context.Continents.FirstOrDefault(n => n.Id == continentId);

        //Update
        public Continent UpdateContinentsById(int continentId, ContinentVM continent)
        {
            var _continent = _context.Continents.FirstOrDefault(n => n.Id == continentId);
            if (_continent != null)
            {
                _continent.ContinentName = continent.ContinentName;
                _context.SaveChanges();
            }
            return _continent;
        }

        //Delete
        public void DeleteContinentById(int continentId)
        {
            var _continent = _context.Continents.FirstOrDefault(n => n.Id == continentId);
            if (_continent != null)
            {
                _context.Continents.Remove(_continent);
                _context.SaveChanges();
            }
        }
    }
}

