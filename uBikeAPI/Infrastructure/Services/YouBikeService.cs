﻿using Microsoft.Extensions.Caching.Memory;
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
                youBikeStations = await _youBikeRepository.FetchYouBikeStations();
                _memoryCache.Set("YouBikeStations", youBikeStations, TimeSpan.FromMinutes(5));
            }
            return youBikeStations ?? new List<YouBikeStationModel>();
        }
    }
}
