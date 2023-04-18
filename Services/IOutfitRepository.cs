using SndAPI.Models;

namespace SndAPI.Services
{
    public interface IOutfitRepository
    {
        Task SaveIDsAsync(OutfitIDs outfitIDs);
        Task<List<OutfitIDs>> GetIdList();
        Task<List<OutfitIDs>> GetIdListToday();
        Task<OutfitIDs> GetIdListLastUpdate();
        Task SaveOuftitDump(List<List<JsonOutfit>> jsonOutfit);
        List<JsonOutfit> GetOufitsLastUpdate();
    }
}