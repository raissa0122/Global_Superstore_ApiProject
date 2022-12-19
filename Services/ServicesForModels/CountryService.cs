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
    public class CountryService
    {
        private AppDbContext _context;
        public CountryService(AppDbContext context)
        {

            _context = context;
        }


        public void AddCountry(Country country)
        {
            var _country = new Country()
            {
                CountryName = country.CountryName
            };
            _context.Countries.Add(_country);
            _context.SaveChanges();
        }

        //GetAll
        public List <Country> GetAllCountries() => _context.Countries.ToList();

        //GetById
        public Country GetCountriesById(int countryId) => _context.Countries.FirstOrDefault(n => n.Id == countryId);

        //Update
        public Country UpdateCountryById(int countryId, CountryVM country)
        {
            var _country = _context.Countries.FirstOrDefault(n => n.Id == countryId);
            if (_country != null)
            {
                _country.CountryName = country.CountryName;
                _context.SaveChanges();
            }
            return _country;
        }

        //Delete
        public void DeleteCountryById(int countryId)
        {
            var _country = _context.Countries.FirstOrDefault(n => n.Id == countryId);
            if (_country != null)
            {
                _context.Countries.Remove(_country);
                _context.SaveChanges();
            }
        }
    }
}

