using Microsoft.AspNetCore.Mvc;
using RobinCanlas.Services;
using System.Diagnostics;

namespace RobinCanlas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController(IPositionStackService positionStackService) : Controller
    {
        private readonly IPositionStackService _positionStackService = positionStackService;

        [HttpGet("{country}")]
        public async Task<IActionResult> GetCountries(string country)
        {
            var result = await _positionStackService.GetCountries(country);
            return Ok(result);
        }
    }
}
