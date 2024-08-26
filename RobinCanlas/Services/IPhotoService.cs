using RobinCanlas.Models;

namespace RobinCanlas.Services
{
    public interface IPhotoService
    {
        Task<List<GetAllFlickrApi>> GetFlickrPhotos();
        Task<List<GetAllCloudinaryApi>> GetCloudinaryPhotos();
        Task<int> DeleteAllPhotos();
        Task<int> InsertFlickrPhotos();
        Task<List<GetAllFlickr>> GetPhotos();
    }
}
