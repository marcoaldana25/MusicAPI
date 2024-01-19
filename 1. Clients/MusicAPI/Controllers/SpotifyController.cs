using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.Managers.Interfaces;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {
        private readonly ILogger<SpotifyController> _logger;

        private readonly ISpotifyManager _spotifyManager;

        public SpotifyController(
            ILogger<SpotifyController> logger,
            ISpotifyManager spotifyManager)
        {
            _logger = logger;
            _spotifyManager = spotifyManager;
        }

        [HttpGet(Name = "GetSpotifyAccount")]
        public async Task<IActionResult> GetSpotifyAccount()
        {
            var spotifyAccount = await _spotifyManager
                .GetSpotifyAccountAsync();

            return Ok(spotifyAccount);
        }
    }
}
