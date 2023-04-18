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

        public async Task GetOutfits()
        {
            var IDs = await _outfitRepository.GetIdListLastUpdate();
            if (IDs.UpdateDate.DayOfYear != DateTime.Now.DayOfYear)
            {
                IDs = await ScrapIDs();
            }
            var client = _bdoApiClient.PostClientOutfitIDs(IDs.IdList!);
            var stringJson = await _arshaService.PostOutfitIDs(client);
            var convertedOutfits = JsonConvert.DeserializeObject<List<List<JsonOutfit>>>(stringJson);
            await _outfitRepository.SaveOuftitDump(convertedOutfits!);
        }

        public async Task<OutfitIDs> ScrapIDs()
        {
            var client = _bdoApiClient.GetClientAll();

            var stringJson = await _arshaService.GetAll(client);
            return await ScrapOutfitIDs(JsonConvert.DeserializeObject<List<JsonItem>>(stringJson));
        }

        private async Task<OutfitIDs> ScrapOutfitIDs(List<JsonItem> jsonItems)
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
                        outfitIDs.Append(item.Id + ",");
                    }
                }
            }

            var allOutfitIDs = new OutfitIDs
            {
                IdList = outfitIDs.ToString().TrimEnd(','),
                UpdateDate = DateTime.Now
            };
            await _outfitRepository.SaveIDsAsync(allOutfitIDs);
            return (allOutfitIDs);
        }
    }
}