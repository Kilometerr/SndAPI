namespace SndAPI.Services
{
    public class OutfitIdUpdateService : BackgroundService
    {
        private readonly PeriodicTimer _timer = new(TimeSpan.FromHours(6)); // scrape every 6 hour
        private readonly IOutfitScrapper _outfitScrapper;
        private readonly ILogger<OutfitIdUpdateService> _logger;
        public OutfitIdUpdateService(IOutfitScrapper outfitScrapper, ILogger<OutfitIdUpdateService> logger)
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
                    await _outfitScrapper.ScrapIDs();
                    _logger.LogInformation("Outfit ID update successful.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Outfit ID update failed.");
                }
            }
        }
    }

}