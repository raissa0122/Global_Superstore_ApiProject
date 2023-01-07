using CsvHelper;
using CsvHelper.Configuration;
using Data;
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
    public class AreaController : ControllerBase
    {
        public AreaService _areaService;
        private AppDbContext _context;

        public AreaController(AreaService areaService, AppDbContext context)
        {
            _areaService = areaService;
            _context = context; 
        }

        [HttpGet("get-all-areas")]
        public IActionResult GetAllAreas()
        {
            var allAreas = _areaService.GetAllAreas();
            return Ok(allAreas);
        }

        [HttpGet("get-areas-by-id/{id}")]
        public IActionResult GetAreasById(int id)
        {
            var areas = _areaService.GetAreaById(id);
            return Ok(areas);
        }

     /*   [HttpPost("add-all-areas-toDb")]
        public IActionResult SaveAreasToDb()
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
                    Area area = new Area();
                    area.Sity = currentResult.City;
                    area.State = currentResult.State;
                    area.PostCode = currentResult.PostalCode;
                    area.Market = currentResult.Market;

                    _areaService.AddArea(area);
                });
            }
            return Ok();
        }*/

        [HttpPost("add-area")]
        public IActionResult AddArea([FromBody]Area area)
        {
            _areaService.AddArea(area);
            return Ok();
        }


        [HttpPut("update-area-by-id/{id}")]
        public IActionResult UpdateAreaById(int id, [FromBody] AreaVM area)
        {
            var updateArea = _areaService.UpdateAreaById(id, area);
            return Ok(updateArea);
        }


        [HttpDelete("delete-areas-by-id/{id}")]
        public IActionResult DeleteAreaById(int id)
        {
            _areaService.DeleteAreaById(id);
            return Ok();  
        }
    }
}
