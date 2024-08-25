using RobinCanlas.Models;

namespace RobinCanlas.Services
{
    public interface ICloudinaryService
    {
        Task<List<GetAllCloudinaryApi>> GetPhotos();

    }
}
