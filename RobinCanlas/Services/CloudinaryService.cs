using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using RobinCanlas.Models;
using System.Net;

namespace RobinCanlas.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        // Set your Cloudinary credentials
        private readonly Cloudinary cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            cloudinary = new Cloudinary(configuration.GetValue<string>("CLOUDINARY_URL"));
            cloudinary.Api.Secure = true;
        }

        public async Task<List<GetAllCloudinaryApi>> GetPhotos()
        {
            try
            {
                var options = new ListResourcesByPrefixParams
                {
                    Prefix = "projects",
                    Type = "upload"
                };
                ListResourcesResult data = await cloudinary.ListResourcesAsync(options);
                if (data.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine($"An error occurred while fetching photos: {data.Error.Message}");
                    return [];
                }
                var photos = data.Resources.Select(resource => new GetAllCloudinaryApi
                {
                    AssetId = resource.AssetId,
                    PublicId = resource.PublicId,
                    Format = resource.Format,
                    Version = resource.Version,
                    ResourceType = resource.ResourceType,
                    Type = resource.Type,
                    CreatedAt = resource.CreatedAt,
                    Bytes = resource.Bytes,
                    Width = resource.Width,
                    Height = resource.Height,
                    Url = resource.Url,
                    SecureUrl = resource.SecureUrl
                }).ToList();

                return photos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching photos: {ex.Message}");
                return [];
            }
        }

    }
}
