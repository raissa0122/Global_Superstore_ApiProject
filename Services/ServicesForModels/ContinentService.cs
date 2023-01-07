using CsvHelper;
using CsvHelper.Configuration;
using Data;
using Models;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        
        public void SaveContinentsToDb()
        {
            String filePath = @"C:\Users\Raissa\source\repos\Global_Superstore_ApiProject\Services\Files\Global_Superstore2.csv";

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };
            //07.12.22г.
            using (StreamReader streamReader = new StreamReader(filePath))
            using (var csvReader = new CsvReader(streamReader, config))
            {
                var records = csvReader.GetRecords<AllTablesModel>().ToList();

                records.ForEach(delegate (AllTablesModel currentResult)
                {
                    Continent continent = new Continent();
                    continent.ContinentName = currentResult.Region;

                });
            }
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

