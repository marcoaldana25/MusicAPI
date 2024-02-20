using Microsoft.AspNetCore.Mvc;
using MusicAPI.Managers.Interfaces;
using MusicAPI.Managers.ViewModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Controllers
{
    /// <summary>
    /// Controler to retrieve data about Playlists from Spotify's Web API.
    /// </summary>
    /// <param name="spotifyManager"></param>
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController(ISpotifyManager spotifyManager) : ControllerBase
    {
        /// <summary>
        /// Get Spotify Catalog information about playlists that match a keyword string.
        /// </summary>
        /// <param name="searchQuery">
        ///     The Search Query.
        /// </param>
        /// <param name="marketCode">
        ///     An ISO 3166-1 alpha-2 country code.
        /// </param>
        /// <param name="limit">
        ///     The maximum number of results to return in each item type.
        /// </param>
        /// <param name="offset">
        ///     The index of the first result to return. Use with limit to get the next page of search results.
        /// </param>
        /// <param name="includeExternal">
        ///     If include_external=audio is specified, it signals that the client can play externally hosted audio content,
        ///     and marks the content as playable in the response. By default externally hosted audio content is marked as unplayable 
        ///     in the response.
        /// </param>
        /// <returns></returns>
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
