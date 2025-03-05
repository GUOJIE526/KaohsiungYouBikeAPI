using Microsoft.AspNetCore.Mvc;
using uBikeAPI.Infrastructure.Interface;

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
            return stations != null ? Ok(stations) : StatusCode(500, "讀取失敗");
        }
    }
}
