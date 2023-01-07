using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class CountryController : ControllerBase
    {
        public CountryService _countryService;
        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("get-all-countries")]
        public IActionResult GetAllCountries()
        {
            var allCountries = _countryService.GetAllCountries();
            return Ok(allCountries);
        }
        [HttpGet("get-countries-by-id/{id}")]
        public IActionResult GetCountriesById(int id)
        {
            var countries = _countryService.GetCountriesById(id);
            return Ok(countries);
        }

        [HttpPost("add-country")]
        public IActionResult AddCountry([FromBody] Country country)
        {
            _countryService.AddCountry(country);
            return Ok();
        }


        [HttpPut("update-country-by-id/{id}")]
        public IActionResult UpdateCountryById(int id, [FromBody] CountryVM country)
        {
            var updateCountry = _countryService.UpdateCountryById(id, country);
            return Ok(updateCountry);
        }


        [HttpDelete("delete-countries-by-id/{id}")]
        public IActionResult DeleteCountryById(int id)
        {
            _countryService.DeleteCountryById(id);
            return Ok();
        }

    }
}

