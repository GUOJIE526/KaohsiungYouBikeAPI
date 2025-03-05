using Microsoft.Extensions.Caching.Memory;
using uBikeAPI.Infrastructure.Interface;
using uBikeAPI.Infrastructure.Models;

namespace uBikeAPI.Infrastructure.Services
{
    public class YouBikeService : IYouBikeService
    {
        private readonly IYouBikeRepository _youBikeRepository;
        private readonly IMemoryCache _memoryCache;

        public YouBikeService(IYouBikeRepository youBikeRepository, IMemoryCache memoryCache)
        {
            _youBikeRepository = youBikeRepository;
            _memoryCache = memoryCache;
        }

        public async Task<List<YouBikeStationModel>> GetYouBikeStations()
        {
            if (!_memoryCache.TryGetValue("YouBikeStations", out List<YouBikeStationModel> youBikeStations))
            {
                var data = await _youBikeRepository.FetchYouBikeStations();
                //如果抓到空陣列就不更新快取
                if (data.Count > 0)
                {
                    _memoryCache.Set("YouBikeStations", youBikeStations, TimeSpan.FromMinutes(5));
                    youBikeStations = data;
                }
            }
            return youBikeStations;
        }
    }
}
