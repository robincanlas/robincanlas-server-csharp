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

        [HttpGet("all/significant/{significantByDayWeekMonth}")]
        public async Task<IActionResult> GetAllSignificant(string significantByDayWeekMonth)
        {
            var result = await _usgsService.GetAllBySignificant(significantByDayWeekMonth);
            return Ok(result);
        }

        [HttpGet("range/{startTime}/{endTime}/{limit}")]
        public async Task<IActionResult> GetByRange(string startTime, string endTime, string? limit = null)
        {
            var result = await _usgsService.GetByRange(startTime, endTime, limit);
            return Ok(result);
        }

        [HttpGet("range/{startTime}/{endTime}/")]
        public async Task<IActionResult> GetByRangeNoLimit(string startTime, string endTime)
        {
            var result = await _usgsService.GetByRange(startTime, endTime);
            return Ok(result);
        }
    }
}
