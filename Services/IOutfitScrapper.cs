namespace SndAPI.Services
{
    public interface IOutfitScrapper
    {
        Task GetOutfits();
        Task Scrap();
    }
}