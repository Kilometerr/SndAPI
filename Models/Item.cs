namespace SndAPI.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public int GameId { get; set; }
        public string? Name { get; set; }
        public int TotalSold { get; set; }
        public int SoldToday { get; set; }
        public int SoldWeek { get; set; }
    }
}