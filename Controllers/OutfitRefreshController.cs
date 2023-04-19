using Microsoft.AspNetCore.Mvc;
using SndAPI.Services;

namespace SndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OutfitRefreshController: Controller
    {
        private readonly IOutfitScrapper _outfitScrapper;

        public OutfitRefreshController(IOutfitScrapper outfitScrapper){
            _outfitScrapper = outfitScrapper;
        }

        [HttpGet]
        public string UpdateOutfits(){
            //TODO HIGH SECURITY RISK
            //PROTECT THE ENDPOINT
            _outfitScrapper.GetOutfits();
            return "OK";
        }
        
    }
}