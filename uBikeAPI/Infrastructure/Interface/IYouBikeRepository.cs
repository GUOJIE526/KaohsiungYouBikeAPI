using uBikeAPI.Infrastructure.Models;

namespace uBikeAPI.Infrastructure.Interface
{
    public interface IYouBikeRepository
    {
        ///<Summary>
        ///取得所有UBike站點資訊
        ///</Summary>
        ///<returns>List<YouBikeStationModel></returns>
        Task<List<YouBikeStationModel>> FetchYouBikeStations();
    }
}
