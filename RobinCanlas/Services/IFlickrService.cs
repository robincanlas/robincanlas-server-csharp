using RobinCanlas.Models;

namespace RobinCanlas.Services
{
    public interface IFlickrService
    {
        Task<List<GetAllFlickrApi>> GetPhotos();
        List<GetAllFlickr> ConstructFlickrPhotos(List<GetAllFlickrApi> photos);
    }
}
