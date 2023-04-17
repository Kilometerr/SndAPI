using Newtonsoft.Json;
using SndAPI.Clients;
using SndAPI.Models;
using System.Text;

namespace SndAPI.Services
{
    public class OutfitScrapper : IOutfitScrapper
    {
        private readonly IArshaService _arshaService;
        private readonly IBdoApiClient _bdoApiClient;
        private readonly IOutfitRepository _outfitRepository;
        public OutfitScrapper(IArshaService arshaService, IBdoApiClient bdoApiClient, IOutfitRepository outfitRepository)
        {
            _arshaService = arshaService;
            _bdoApiClient = bdoApiClient;
            _outfitRepository = outfitRepository;
        }

        public async Task Scrap()
        {
            var client = _bdoApiClient.GetClientAll();
            var stringJson = await _arshaService.GetAll(client);
            var outfitIDs = ScrapOutfitIDs(JsonConvert.DeserializeObject<List<JsonItem>>(stringJson));
            await _outfitRepository.SaveIDsAsync(outfitIDs);
        }

        private static OutfitIDs ScrapOutfitIDs(List<JsonItem> jsonItems)
        {
            var outfitIDs = new StringBuilder();
            foreach (var item in jsonItems)
            {
                if (item.Name.Contains("Outfit Set") || item.Name.Contains("Premium Set"))
                {
                    outfitIDs.Append(item.Id);
                    outfitIDs.Append(",");
                }
            }

            return new OutfitIDs
            {
                IdList = outfitIDs.ToString().TrimEnd(','),
                UpdateDate = DateTime.Now
            };
        }
    }
}