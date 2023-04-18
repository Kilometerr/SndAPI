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

        public Task GetOutfits()
        {
            throw new NotImplementedException();
        }

        public async Task Scrap()
        {
            var client = _bdoApiClient.GetClientAll();

            var stringJson = await _arshaService.GetAll(client);
            ScrapOutfitIDs(JsonConvert.DeserializeObject<List<JsonItem>>(stringJson));

        }

        private async void ScrapOutfitIDs(List<JsonItem> jsonItems)
        {
            var outfitIDs = new StringBuilder();
            var clientID = _bdoApiClient.GetClientList();

            foreach (var item in jsonItems)
            {
                if (item.Name.Contains("Outfit Set") || item.Name.Contains("Premium Set"))
                {
                    var outfit = await _arshaService.GetById(clientID, (int)item.Id);
                    if (!outfit.Contains("null"))
                    {
                        outfitIDs.Append(item.Id+",");
                    }
                }
            }

            var allOutfitIDs = new OutfitIDs
            {
                IdList = outfitIDs.ToString().TrimEnd(','),
                UpdateDate = DateTime.Now
            };
            await _outfitRepository.SaveIDsAsync(allOutfitIDs);
        }
    }
}