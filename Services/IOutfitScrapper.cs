using SndAPI.Models;
namespace SndAPI.Services
{
    public interface IOutfitScrapper
    {
        Task GetOutfits();
        Task<OutfitIDs> ScrapIDs();
    }
}