namespace SndAPI.Services
{
    public class SoldOutfitsUpdateService: BackgroundService
    {
        private readonly PeriodicTimer _timer = new(TimeSpan.FromMinutes(15)); // scrape every 30mins
        private readonly ILogger<OutfitIdUpdateService> _logger;
        private readonly IOutfitScrapper _outfitScrapper;
        public SoldOutfitsUpdateService(IOutfitScrapper outfitScrapper, ILogger<OutfitIdUpdateService> logger)
        {
            _outfitScrapper = outfitScrapper;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (await _timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _outfitScrapper.GetOutfits();
                    _logger.LogInformation("Getting outfits successful.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Getting outfits failed.");
                }
            }
        }
    }
}