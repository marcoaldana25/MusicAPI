using Microsoft.AspNetCore.Mvc;
using MusicAPI.Managers.Interfaces;
using MusicAPI.Managers.ViewModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Controllers
{
    /// <summary>
    /// Controller for Client integration targeting Spotify's Web API, specifially around Users information.
    /// </summary>
    /// <param name="spotifyManager"></param>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(ISpotifyManager spotifyManager) : ControllerBase
    {
        /// <summary>
        ///     Get detailed profile information about the current user (including the current user's username)
        /// </summary>
        /// <returns>
        ///     Detailed profile information about the current authorized user.
        /// </returns>
        [HttpGet]
        [Route("accountDetails")]
        [Produces(typeof(OkObjectResult))]
        public async Task<IActionResult> GetAccountDetails()
        {
            var spotifyAccount = await spotifyManager
                .GetSpotifyAccountAsync();

            return Ok(spotifyAccount);
        }
    }
}
