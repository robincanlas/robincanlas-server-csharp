using RobinCanlas.Models;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net;
using System.Text.Json;

namespace RobinCanlas.Services
{
    public class PositionStackService: IPositionStackService
    {
        private readonly string? host;
        private readonly string? access_key;
        private static readonly HttpClient client = new();

        public PositionStackService()
        {
            host = Environment.GetEnvironmentVariable("POSITION_STACK_API");
            access_key = Environment.GetEnvironmentVariable("POSITION_STACK_API_ACCESS_KEY");
        }

        public async Task<List<PositionStackCountry>> GetCountries(string country)
        {
            //Debug.WriteLine(string.Format($"{host}forward/access_key={0}&query={1}"));
            //var response = await client.GetAsync(string.Format($"{host}forward?access_key={0}&query={1}", access_key, country));

            //if (!response.IsSuccessStatusCode)
            //    throw new Exception($"{response.StatusCode}: {response.ReasonPhrase}");
            //var responseObject = await response.Content.ReadFromJsonAsync<List<PositionStackCountry>>();
            //return responseObject;
            //var json = await client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
            var json = await client.GetStringAsync("https://api.positionstack.com/v1/forward?access_key=c31a02917fd4ee880dbb0f51d6faa1d2&query=paris");
            //PositionStackCountryData deserializedObject = JsonSerializer.Deserialize<PositionStackCountryData>(json);
            //var responseObject = JsonSerializer.Deserialize<List<PositionStackCountry>>(json);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            PositionStackCountryData deserializedObject = JsonSerializer.Deserialize<PositionStackCountryData>(json, options);


            //return responseObject;
            return deserializedObject.Data;

            //var json = await client.GetStringAsync("https://api.positionstack.com/v1/forward?access_key=c31a02917fd4ee880dbb0f51d6faa1d2&query=paris");
            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //};
            //var responseObject = JsonSerializer.Deserialize<List<PositionStackCountry>>(json, options);
            //return responseObject ?? new List<PositionStackCountry>();
        }

    }
}
