using Microsoft.AspNetCore.Mvc;
using RobinCanlas.Services;

namespace RobinCanlas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController(IFlickrService flickrService, ICloudinaryService cloudinaryService) : Controller
    {
        private readonly IFlickrService _flickrService = flickrService;
        private readonly ICloudinaryService _cloudinaryService = cloudinaryService;

        [HttpGet("flickr")]
        public async Task<IActionResult> GetFlickrPhotos()
        {
            var photos = await _flickrService.GetPhotos();
            return Ok(photos);
        }

        [HttpGet("cloudinary")]
        public async Task<IActionResult> GetCloudinaryPhotos()
        {
            var photos = await _cloudinaryService.GetPhotos();
            return Ok(photos);
        }
    }
}
