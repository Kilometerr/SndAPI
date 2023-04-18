using Microsoft.EntityFrameworkCore;
using SndAPI.Models;
namespace SndAPI.Data
{
    public class SndDbContext : DbContext
    {
        public SndDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<JsonOutfit> OutfitDump { get; set; }
        public DbSet<OutfitIDs> OutfitIDs { get; set; }
    }
}