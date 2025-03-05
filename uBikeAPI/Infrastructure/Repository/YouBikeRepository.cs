using Newtonsoft.Json;
using System.IO.Compression;
using uBikeAPI.Infrastructure.Interface;
using uBikeAPI.Infrastructure.Models;

namespace uBikeAPI.Infrastructure.Repository
{
    public class YouBikeRepository : IYouBikeRepository
    {
        private readonly HttpClient _httpClient;
        private const string uBikeUrl = "https://api.kcg.gov.tw/api/service/Get/b4dd9c40-9027-4125-8666-06bef1756092";

        public YouBikeRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<YouBikeStationModel>> FetchYouBikeStations()
        {
            try
            {
                using var response = await _httpClient.GetAsync(uBikeUrl);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UBikeApiResponse>(json);
                return data?.Data?.RetVal ?? new List<YouBikeStationModel>();
            }
            catch
            {
                return new List<YouBikeStationModel>();
            }
        }
    }
}
