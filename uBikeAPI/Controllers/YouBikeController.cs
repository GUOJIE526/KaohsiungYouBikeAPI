using Microsoft.AspNetCore.Mvc;
using uBikeAPI.Infrastructure.Interface;
using uBikeAPI.Infrastructure.Models;

namespace uBikeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YouBikeController : Controller
    {
        private readonly IYouBikeService _youBikeService;
        public YouBikeController(IYouBikeService youBikeService)
        {
            _youBikeService = youBikeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetYouBikeStations()
        {
            var stations = await _youBikeService.GetYouBikeStations();
            return Ok(stations ?? new List<YouBikeStationModel>()); //有可能斷網會回傳204, 回傳空陣列
        }
    }
}
