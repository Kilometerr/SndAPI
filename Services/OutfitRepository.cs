
using SndAPI.Data;
using SndAPI.Models;
using SndAPI.Comparers;
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

        public List<Item?> GetOufitsSoldToday()
        {
            var jsonOutfits = new List<Item>();

            var distinct = _sndDbContext.OutfitDump
            .Where(g=>g.UpdateDate.DayOfYear==DateTime.Now.DayOfYear)
            .GroupBy(g=>new{g.GameId, g.UpdateDate.Date})
            .Select(group => group.OrderBy(g=>g.UpdateDate).First())
            .ToList();

            foreach (var item in distinct)
            {
             System.Console.WriteLine(item);   
            }

            var newDistinct = _sndDbContext.OutfitDump
            .Where(g=>g.UpdateDate.DayOfYear==DateTime.Now.DayOfYear)
            .GroupBy(g => g.GameId)
            .Select(group => group.OrderByDescending(g => g.UpdateDate).First())
            .ToList();

            var toCompare = newDistinct.Join(
                distinct,
                n => n.GameId,
                d => d.GameId,
                (n,d) => new {newDistinct = n, distinct = d}
            );

            foreach (var item in toCompare)
            {
                if(item.newDistinct.TotalTrades>item.distinct.TotalTrades){
                    jsonOutfits.Add(new Item
                    {
                        GameId = item.newDistinct.GameId,
                        Name = item.newDistinct.Name,
                        TotalSold = item.newDistinct.TotalTrades,
                        SoldToday = item.newDistinct.TotalTrades - item.distinct.TotalTrades,
                        SoldWeek = item.newDistinct.TotalTrades - item.distinct.TotalTrades
                    });
                }
            }
            return jsonOutfits.Distinct(new ItemComparer()).ToList();
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