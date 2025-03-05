using uBikeAPI.Infrastructure.Models;

namespace uBikeAPI.Infrastructure.Interface
{
    public interface IYouBikeService
    {
        Task<List<YouBikeStationModel>> GetYouBikeStations();
    }
}
