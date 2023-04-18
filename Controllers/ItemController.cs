using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SndAPI.Clients;
using SndAPI.Services;
using SndAPI.Data;
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

        //todo add so it gets id from form on site
        [HttpGet]
        public List<Item> GetList() //controller for tests
        {
            return _outfitRepository.GetOufitsSoldToday();
        }
    }
}