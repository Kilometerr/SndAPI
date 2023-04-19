using Microsoft.AspNetCore.Mvc;
using SndAPI.Services;

namespace SndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdRefresh : Controller
    {
        private readonly IOutfitScrapper _outfitScrapper;

        public IdRefresh(IOutfitScrapper outfitScrapper)
        {
            _outfitScrapper = outfitScrapper;
        }

        [HttpGet]
        public string UpdateItemsIDs()
        {
            //TODO HIGH SECURITY RISK
            //PROTECT THE ENDPOINT
            _outfitScrapper.ScrapIDs();
            return "OK";
        }
    }
}