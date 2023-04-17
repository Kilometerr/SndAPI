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

        public async Task<String> GetById(HttpClient httpClient, int id)
        {
            using HttpResponseMessage response = await httpClient.GetAsync($"?ids={id}");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }

    }
}
