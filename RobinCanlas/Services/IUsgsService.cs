using CloudinaryDotNet;
using RobinCanlas.Models;

namespace RobinCanlas.Services
{
    public interface IUsgsService
    {
        public Task<UsgsGet> GetAllBy(string byAll);
        public Task<UsgsGet> GetAllBySignificant(string bySignificant);
        public Task<UsgsGet> GetByRange(string startTime, string endTime, string? limit = null);
    }
}
