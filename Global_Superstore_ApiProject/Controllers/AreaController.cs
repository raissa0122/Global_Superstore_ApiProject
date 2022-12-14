using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels;
using Services.ServicesForModels;

namespace Global_Superstore_ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        public AreaService _areaService;

        public AreaController(AreaService areaService)
        {
            _areaService = areaService;
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
