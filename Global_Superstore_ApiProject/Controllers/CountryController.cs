using CsvHelper;
using CsvHelper.Configuration;
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
    public class CountryController : ControllerBase
    {
        public CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [Authorize(Roles = "admin, user")]
        [HttpGet("get-all-countries")]
        public IActionResult GetAllCountries()
        {
            var allCountries = _countryService.GetAllCountries();
            return Ok(allCountries);
        }

        [Authorize(Roles = "admin, user")]
        [HttpGet("get-countries-by-id/{id}")]
        public IActionResult GetCountriesById(int id)
        {
            var countries = _countryService.GetCountriesById(id);
            return Ok(countries);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("add-country")]
        public IActionResult AddCountry([FromBody] Country country)
        {
            _countryService.AddCountry(country);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpPut("update-country-by-id/{id}")]
        public IActionResult UpdateCountryById(int id, [FromBody] CountryVM country)
        {
            var updateCountry = _countryService.UpdateCountryById(id, country);
            return Ok(updateCountry);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("delete-countries-by-id/{id}")]
        public IActionResult DeleteCountryById(int id)
        {
            _countryService.DeleteCountryById(id);
            return Ok();
        }

    }
}

