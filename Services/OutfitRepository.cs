using SndAPI.Data;
using SndAPI.Models;

namespace SndAPI.Services
{
    public class OutfitRepository : IOutfitRepository
    {
        private readonly SndDbContext _sndDbContext;

        public OutfitRepository(SndDbContext sndDbContext)
        {
            _sndDbContext = sndDbContext;
        }

        public async Task SaveIDsAsync(OutfitIDs outfitIDs)
        {
            await _sndDbContext.OutfitIDs.AddAsync(outfitIDs);
            await _sndDbContext.SaveChangesAsync();
        }
    }
}