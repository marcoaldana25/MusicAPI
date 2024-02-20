using Microsoft.AspNetCore.Mvc;
using MusicAPI.Managers.Interfaces;
using MusicAPI.Managers.ViewModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController(ISpotifyManager spotifyManager) : ControllerBase
    {
        [HttpGet]
        [Route("search")]
        [Produces(typeof(OkObjectResult))]
        public async Task<IActionResult> GetSearchAsync(
            [Required] string searchQuery,
            [Required] string marketCode,
            int? limit = null,
            int? offset = null,
            string? includeExternal = null)
        {
            var searchResult = await spotifyManager
                .GetSearchAsync(searchQuery, SearchType.Playlist, marketCode, limit, offset, includeExternal);

            return Ok(searchResult.Playlists);
        }
    }
}
