using RobinCanlas.Models;
using System.Text.Json;

namespace RobinCanlas.Services
{
    public class FlickrService(IConfiguration configuration) : IFlickrService
    {
        private readonly string? host = configuration.GetValue<string>("FLICKER_API");
        private static readonly HttpClient client = new();

        public async Task<List<GetAllFlickrApi>> GetPhotos()
        {
            try
            {
                var json = await client.GetStringAsync(host);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                FlickrPhotos deserializedObject = JsonSerializer.Deserialize<FlickrPhotos>(json, options);
                return deserializedObject!.Photos.Photo;
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred while fetching photos: {ex.Message}");
                return new List<GetAllFlickrApi>();
            }
        }
        public List<GetAllFlickr> ConstructFlickrPhotos(List<GetAllFlickrApi> photos)
        {
            List<GetAllFlickr> newPhotos = [];
            for (int i = 0; i < photos.Count; i++)
            {
                newPhotos.Add(new GetAllFlickr
                {
                    Id = i,
                    Index = i,
                    Thumbnail = $"https://farm{photos[i].Farm}.staticflickr.com/{photos[i].Server}/{photos[i].Id}_{photos[i].Secret}_z.jpg",
                    Url = $"https://farm{photos[i].Farm}.staticflickr.com/{photos[i].Server}/{photos[i].Id}_{photos[i].Secret}_b.jpg",
                    Src = $"https://farm{photos[i].Farm}.staticflickr.com/{photos[i].Server}/{photos[i].Id}_{photos[i].Secret}_b.jpg",
                    Raw = $"https://farm{photos[i].Farm}.staticflickr.com/{photos[i].Server}/{photos[i].Id}_{photos[i].Secret}",
                    Original = photos[i].Url_o
                });
            }
            return newPhotos;
        }
    }
}
