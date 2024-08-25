using RobinCanlas.Models;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net;
using System.Text.Json;

namespace RobinCanlas.Services
{
    public class PositionStackService(IConfiguration configuration) : IPositionStackService
    {
        private readonly string? host = configuration.GetValue<string>("POSITION_STACK_API");
        private readonly string? access_key = configuration.GetValue<string>("POSITION_STACK_API_ACCESS_KEY");
        private static readonly HttpClient client = new();

        public async Task<List<PositionStackCountry>> GetCountries(string country)
        {
            try
            {
                var json = await client.GetStringAsync($"{host}forward?access_key={access_key}&query={country}");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                PositionStackCountryData deserializedObject = JsonSerializer.Deserialize<PositionStackCountryData>(json, options);
                return deserializedObject!.Data;
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred while fetching countries: {ex.Message}");
                return new List<PositionStackCountry>();
            }
        }

    }
}
