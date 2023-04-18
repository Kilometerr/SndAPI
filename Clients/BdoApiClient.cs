namespace SndAPI.Clients
{
    public class BdoApiClient : IBdoApiClient
    {
        public HttpClient GetClientAll()
        {
            return new()
            {
                BaseAddress = new Uri("https://api.arsha.io/util/db/dump?lang=en")
            };
        }

        public HttpClient GetClientList()
        {
            return new()
            {
                BaseAddress = new Uri("https://api.arsha.io/v2/eu/GetWorldMarketSearchList"),
            };
        }

        public HttpClient PostClientOutfitIDs(string ids)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.arsha.io/v2/eu/GetWorldMarketSubList");
            client.DefaultRequestHeaders.Add("id",ids);
            return client;
        }
    }
}