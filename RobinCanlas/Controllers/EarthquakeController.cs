using Microsoft.AspNetCore.Mvc;
using RobinCanlas.Services;

namespace RobinCanlas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Earthquake Service")]
    public class EarthquakeController(IUsgsService usgsService) : Controller
    {
        private readonly IUsgsService _usgsService = usgsService;

        [HttpGet("all/by/{byDayWeekMonth}")]
        public async Task<IActionResult> GetAllDay(string byDayWeekMonth)
        {
            var result = await _usgsService.GetAllBy(byDayWeekMonth);
            return Ok(result);
        }

    }
}
