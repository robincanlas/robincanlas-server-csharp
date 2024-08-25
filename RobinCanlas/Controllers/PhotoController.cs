using Microsoft.AspNetCore.Mvc;
using RobinCanlas.Services;

namespace RobinCanlas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController(IFlickrService flickrService) : Controller
    {
        private readonly IFlickrService _flickrService = flickrService;

        [HttpGet("flickr")]
        public async Task<IActionResult> GetFlickrPhotos()
        {
            var photos = await _flickrService.GetPhotos();
            return Ok(photos);
        }
    }
}
