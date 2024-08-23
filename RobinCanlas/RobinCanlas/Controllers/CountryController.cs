using Microsoft.AspNetCore.Mvc;
using RobinCanlas.Services;
using System.Diagnostics;

namespace RobinCanlas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly IPositionStackService _positionStackService;

        public CountryController(IPositionStackService positionStackService)
        {
            _positionStackService = positionStackService;
        }

        [HttpGet("{country}")]
        //[HttpGet]
        public async Task<IActionResult> GetCountries(string country)
        //public async Task<IActionResult> GetCountries()
        {
            //Debug.WriteLine("hellowww");
            //return Ok("Hello World");
            var result = await _positionStackService.GetCountries(country);

            return Ok(result);
        }
    }
}
