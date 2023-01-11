using CsvHelper;
using CsvHelper.Configuration;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.ViewModels;
using Services.ServicesForModels;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
namespace Global_Superstore_ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentController : ControllerBase
    {

        public ContinentService _continentService;

 

        public ContinentController(ContinentService continentService)
        {
            _continentService = continentService;
           
        }

        [HttpGet("get-all-continents")]
        public IActionResult GetAllContinents()
        {
            var allContinents = _continentService.GetAllContinents();
            return Ok(allContinents);
        }
        [HttpGet("get-continents-by-id/{id}")]
        public IActionResult GetContinentsById(int id)
        {
            var continents = _continentService.GetContinentsById(id);
            return Ok(continents);
        }


        //premesti nqkade
      /*  [HttpPost("add-all-continents-toDb")]
        public IActionResult SaveContinentsToDb()
        {
            String filePath = @"C:\Files\Global_Superstore2.csv";

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

                    _continentService.AddContinent(continent);
                });
            }
            return Ok();
        }*/



        [HttpPost("add-continent")]
        public IActionResult AddContinent([FromBody] Continent continent)
        {
            _continentService.AddContinent(continent);
            return Ok();
        }


        [HttpPut("update-continent-by-id/{id}")]
        public IActionResult UpdateContinentById(int id, [FromBody] ContinentVM continent)
        {
            var updateContinent = _continentService.UpdateContinentsById(id, continent);
            return Ok(updateContinent);
        }


        [HttpDelete("delete-continents-by-id/{id}")]
        public IActionResult DeleteContinentById(int id)
        {
            _continentService.DeleteContinentById(id);
            return Ok();
        }

    }
}

