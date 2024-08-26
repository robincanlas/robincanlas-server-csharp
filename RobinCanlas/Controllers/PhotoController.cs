using Microsoft.AspNetCore.Mvc;
using RobinCanlas.Services;

namespace RobinCanlas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController(IPhotoService photoService) : Controller
    {
        private readonly IPhotoService _photoService = photoService;

        [HttpGet("flickr")]
        public async Task<IActionResult> GetFlickrPhotos()
        {
            var photos = await _photoService.GetFlickrPhotos();
            return Ok(photos);
        }

        [HttpGet("cloudinary")]
        public async Task<IActionResult> GetCloudinaryPhotos()
        {
            var photos = await _photoService.GetCloudinaryPhotos();
            return Ok(photos);
        }
    }
}
