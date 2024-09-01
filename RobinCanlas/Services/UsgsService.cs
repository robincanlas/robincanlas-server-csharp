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
        private static readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

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
                UsgsGet deserializedObject = JsonSerializer.Deserialize<UsgsGet>(json, jsonSerializerOptions);
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

        public async Task<UsgsGet> GetAllBySignificant(string bySignificant)
        {
            try
            {
                string bySignificantDictionary = _dictionary[bySignificant];
                var json = await client.GetStringAsync($"{host}{feedSummary}{bySignificantDictionary}");
                UsgsGet deserializedObject = JsonSerializer.Deserialize<UsgsGet>(json, jsonSerializerOptions);
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

        public async Task<UsgsGet> GetByRange(string startTime, string endTime, string? limit = null)
        {
            var query = $"starttime={startTime}&endtime={endTime}";
            query = limit != null ? query + $"&limit={limit}" : query;
            try
            {
                var json = await client.GetStringAsync($"{host}{fdsnws}query?format=geojson&{query}");
                UsgsGet deserializedObject = JsonSerializer.Deserialize<UsgsGet>(json, jsonSerializerOptions);
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

//https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
// https://earthquake.usgs.gov/fdsnws/event/1/