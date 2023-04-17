using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SndAPI.Clients;
using SndAPI.Services;
using SndAPI.Data;

namespace SndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IArshaService _arshaService;
        private readonly IBdoApiClient _bdoApiClient;
        private readonly SndDbContext _sndDbContext;

        public ItemController(IArshaService arshaService, IBdoApiClient bdoApiClient, SndDbContext sndDbContext)
        {
            _arshaService = arshaService;
            _bdoApiClient = bdoApiClient;
            _sndDbContext = sndDbContext;
        }

        //todo add so it gets id from form on site
        [HttpGet]
        public async Task<IActionResult> GetList() //controller for tests
        {
            var Ids = await _sndDbContext.OutfitIDs.ToListAsync();
            return Ok(Ids);
        }
    }
}