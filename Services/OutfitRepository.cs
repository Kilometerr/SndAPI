using SndAPI.Data;
using SndAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SndAPI.Services
{
    public class OutfitRepository : IOutfitRepository
    {
        private readonly SndDbContext _sndDbContext;

        public OutfitRepository(SndDbContext sndDbContext)
        {
            _sndDbContext = sndDbContext;
        }

        public async Task<List<OutfitIDs>> GetIdList()
        {
            return await _sndDbContext.OutfitIDs.ToListAsync();
        }

        public async Task<OutfitIDs> GetIdListLastUpdate()
        {
            return await _sndDbContext.OutfitIDs.OrderByDescending(b => b.UpdateDate).FirstAsync();
        }

        public async Task<List<OutfitIDs>> GetIdListToday()
        {
            return await _sndDbContext.OutfitIDs.Where(b => b.UpdateDate.DayOfYear == DateTime.Now.DayOfYear).ToListAsync();
        }

        public List<JsonOutfit?> GetOufitsLastUpdate()
        {
            return _sndDbContext.OutfitDump
            .GroupBy(g => g.GameId)
            .Select(group => group.OrderByDescending(g => g.UpdateDate).FirstOrDefault())
            .ToList();
        }

        public async Task SaveIDsAsync(OutfitIDs outfitIDs)
        {
            await _sndDbContext.OutfitIDs.AddAsync(outfitIDs);
            await _sndDbContext.SaveChangesAsync();
        }

        public async Task SaveOuftitDump(List<List<JsonOutfit>> jsonOutfits)
        {
            foreach (var item in jsonOutfits)
            {
                foreach (var outfit in item)
                {
                    outfit.UpdateDate = DateTime.Now;
                    await _sndDbContext.OutfitDump.AddAsync(outfit);
                }
            }
            await _sndDbContext.SaveChangesAsync();
        }
    }
}