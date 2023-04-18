
namespace SndAPI.Services
{
    public interface IArshaService
    {
        Task<string> GetById(HttpClient httpClient, int id);
        Task<string> GetAll(HttpClient httpClient);
        Task<string> PostOutfitIDs(HttpClient httpClient);
    }
}