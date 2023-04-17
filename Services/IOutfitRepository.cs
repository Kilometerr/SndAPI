using SndAPI.Models;

namespace SndAPI.Services
{
    public interface IOutfitRepository
    {
        Task SaveIDsAsync(OutfitIDs outfitIDs);
    }
}