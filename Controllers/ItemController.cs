using Microsoft.AspNetCore.Mvc;
using SndAPI.Services;
using SndAPI.Models;

namespace SndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IOutfitRepository _outfitRepository;

        public ItemController(IOutfitRepository outfitRepository)
        {
            _outfitRepository = outfitRepository;
        }

        [HttpGet]
        public List<Item> GetList()
        {
            return _outfitRepository.GetOufitsSoldToday();
        }
    }
}