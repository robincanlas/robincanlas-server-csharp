using RobinCanlas.Models;
using System.Text.Json;

namespace RobinCanlas.Services
{
    public class UsgsService(IConfiguration configuration) : IUsgsService
    {
        private readonly string? host = configuration.GetValue<string>("USGS_API");
        private static readonly string fdsnws = "/fdsnws/event/1/";
        private static readonly string feedSummary = "/earthquakes/feed/v1.0/summary/";
        private static readonly HttpClient client = new();

        private readonly Dictionary<string, string> _dictionary = new()
        {
            {"significantByDay", "significant_day.geojson"},
            {"significantByWeek", "significant_week.geojson"},
            {"significantByMonth", "significant_month.geojson"},
            {"byAllDay", "all_day.geojson"},
            {"byAllWeek", "all_week.geojson"},
            {"byAllMonth", "all_month.geojson"}
         };

        public async Task<UsgsGet> GetAllBy(string byAll)
        {
            try
            {
                string byAllDictionary = _dictionary[byAll];
                var json = await client.GetStringAsync($"{host}{feedSummary}{byAllDictionary}");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                UsgsGet deserializedObject = JsonSerializer.Deserialize<UsgsGet>(json, options);
                if (deserializedObject == null)
                {
                    return new UsgsGet();
                }
                return deserializedObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching data: {ex.Message}");
                return new UsgsGet();
            }
        }
    }
}
