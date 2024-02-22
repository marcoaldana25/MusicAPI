using Microsoft.AspNetCore.Mvc;
using MusicAPI.Managers.Interfaces;
using MusicAPI.Managers.ViewModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Controllers
{
    /// <summary>
    /// Controller for Client integration targeting Spotify's Web API, specifically around Track information.
    /// </summary>
    /// <param name="spotifyManager"></param>
    [ApiController]
    [Route("api/[controller]")]
    public class TracksController(ISpotifyManager spotifyManager) : ControllerBase
    {
        /// <summary>
        /// Get Spotify Catalog informatino about tracks that match a keyword string.
        /// </summary>
        /// <param name="searchQuery">
        ///     The Search Query.
        /// </param>
        /// <param name="marketCode">
        ///     An ISO 3166-1 alpha-2 country code.    
        /// </param>
        /// <param name="limit">
        ///     The maximum umber of results to return in each item type.
        /// </param>
        /// <param name="offset">
        ///     The index of the first result to return. Use with limit to get the next page of search resutls.
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
                .GetSearchAsync(searchQuery, SearchType.Track, marketCode, limit, offset, includeExternal);

            return Ok(searchResult.Tracks);
        }
    }
}
