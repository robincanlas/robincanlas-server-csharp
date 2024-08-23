using RobinCanlas.Models;

namespace RobinCanlas.Services
{
    public interface IPositionStackService
    {
        Task<List<PositionStackCountry>> GetCountries(string country);

    }
}
