
namespace SndAPI.Clients
{
    public interface IBdoApiClient
    {
        HttpClient GetClientList();
        HttpClient GetClientAll();
        HttpClient PostClientOutfitIDs(string ids);
    }
}