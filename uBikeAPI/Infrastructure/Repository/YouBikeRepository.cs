using Newtonsoft.Json;
using System.IO.Compression;
using uBikeAPI.Infrastructure.Interface;
using uBikeAPI.Infrastructure.Models;

namespace uBikeAPI.Infrastructure.Repository
{
    public class YouBikeRepository : IYouBikeRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string uBikeUrl = "https://api.kcg.gov.tw/api/service/Get/b4dd9c40-9027-4125-8666-06bef1756092";

        public YouBikeRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<YouBikeStationModel>> FetchYouBikeStations()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(uBikeUrl);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Rootobject>(json);
                return result.data.retVal;
            }
            catch
            {
                return new List<YouBikeStationModel>();
            }
        }
    }
}
