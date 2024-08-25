using RobinCanlas.Models;

namespace RobinCanlas.Services
{
    public interface IFlickrService
    {
        Task<List<GetAllFlickrApi>> GetPhotos();
    }
}
