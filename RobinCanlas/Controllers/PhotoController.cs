using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RobinCanlas.Models;
using RobinCanlas.Services;

namespace RobinCanlas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Photo Service")]
    public class PhotoController(IPhotoService photoService, IConfiguration configuration) : Controller
    {
        private readonly IPhotoService _photoService = photoService;

        [HttpGet]
        public async Task<IActionResult> GetPhotos()
        {
            var photos = await _photoService.GetPhotos();
            return Ok(photos);
        }

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

        [HttpPut("syncFlickrAndPostgresDB")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SyncFlickrAndPostgresDB([FromBody] Validation validation)
        {
            if (validation.MasterPassword != configuration.GetValue<string>("MASTER_PASSWORD"))
            {
                return Unauthorized();
            }
            await _photoService.DeleteAllPhotos();
            int rowsAffected = await _photoService.InsertFlickrPhotos();
            if (rowsAffected == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
