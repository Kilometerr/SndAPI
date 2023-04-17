
namespace SndAPI.Services
{
    public interface IArshaService
    {
        Task<String> GetById(HttpClient httpClient, int id);
        Task<String> GetAll(HttpClient httpClient);
    }
}