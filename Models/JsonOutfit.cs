namespace SndAPI.Models
{
    public class JsonOutfit
    {
        public string? Name{get;set;}
        public string? Icon{get;set;}
        public int Id{get;set;}
        public int Sid{get;set;}
        public int MinEnhance{get;set;}
        public int Maxenhance{get;set;}
        public int BasePrice{get;set;}
        public int CurrentStock{get;set;}
        public int TotalTrades{get;set;}
        public int PriceMin{get;set;}
        public int PriceMax{get;set;}
        public int LastSoldPrice{get;set;}
        public int LastSoldTime{get;set;}
    }
}