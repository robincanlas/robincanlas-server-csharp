using RobinCanlas.Models;

namespace RobinCanlas.Services
{
    public class PhotoService(IFlickrService flickrService, ICloudinaryService cloudinaryService) : IPhotoService
    {
        private readonly IFlickrService _flickrService = flickrService;
        private readonly ICloudinaryService _cloudinaryService = cloudinaryService;

        public async Task<List<GetAllFlickrApi>> GetFlickrPhotos()
        {
            var photos = await _flickrService.GetPhotos();
            return photos;
        }

        public async Task<List<GetAllCloudinaryApi>> GetCloudinaryPhotos()
        {
            var photos = await _cloudinaryService.GetPhotos();
            return photos;
        }
    }
}
