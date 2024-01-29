using Microsoft.AspNetCore.Mvc;
using MusicAPI.Managers.Interfaces;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyController(ISpotifyManager spotifyManager) : ControllerBase
    {
        [HttpGet]
        [Route("/GetAccountDetails")]
        public async Task<IActionResult> GetAccountDetails()
        {
            var spotifyAccount = await spotifyManager
                .GetSpotifyAccountAsync();

            return Ok(spotifyAccount);
        }
    }
}
