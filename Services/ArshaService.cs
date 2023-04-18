using Newtonsoft.Json.Linq;
using SndAPI.Clients;

namespace SndAPI.Services
{
    public class ArshaService : IArshaService
    {
        public async Task<string> GetAll(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.GetAsync("");
            response.EnsureSuccessStatusCode().WriteRequestToConsole();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }

        public async Task<string> GetById(HttpClient httpClient, int id)
        {
            using HttpResponseMessage response = await httpClient.GetAsync($"?ids={id}");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }

        public async Task<string> PostOutfitIDs(HttpClient httpClient)
        {
            StringContent queryString = new StringContent("");
            using HttpResponseMessage response = await httpClient.PostAsync("", queryString);
            response.EnsureSuccessStatusCode().WriteRequestToConsole();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
