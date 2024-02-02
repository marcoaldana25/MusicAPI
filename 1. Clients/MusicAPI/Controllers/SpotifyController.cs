﻿using Microsoft.AspNetCore.Mvc;
using MusicAPI.Managers.Interfaces;
using MusicAPI.Managers.ViewModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Controllers
{
    /// <summary>
    /// Controller for Client integration targeting Spotify's Web API.
    /// </summary>
    /// <param name="spotifyManager"></param>
    [ApiController]
    [Route("api/[controller]")]
    public class SpotifyController(ISpotifyManager spotifyManager) : ControllerBase
    {
        /// <summary>
        ///     Get detailed profile information about the current user (including the current user's username)
        /// </summary>
        /// <returns>
        ///     Detailed profile information about the current authorized user.
        /// </returns>
        [HttpGet]
        [Route("/GetAccountDetails")]
        [Produces(typeof(OkObjectResult))]
        public async Task<IActionResult> GetAccountDetails()
        {
            var spotifyAccount = await spotifyManager
                .GetSpotifyAccountAsync();

            return Ok(spotifyAccount);
        }

        /// <summary>
        ///     Returns Spotify catalog information about Albums, Artists, Playlists, Tracks, Shows, Episodes,
        ///     or Audiobooks that match a keyword string. Audiobooks are only available within the US, UK, Canada, Ireland,
        ///     New Zealand and Australia markets.
        /// </summary>
        /// <param name="searchQuery">
        ///     The search query.
        /// </param>
        /// <param name="searchType">
        ///     Item type to execute the search across.
        /// </param>
        /// <param name="marketCode">
        ///     An ISO 3166-1 alpha-2 country code.
        ///     If a County Code is specified, only content that is available in that market will be returned.
        /// </param>
        /// <param name="limit">The maximum number of results to return in each item type. Deafult is 20. The acceptable range is 0-50.</param>
        /// <param name="offset">
        ///     The index of the first result to return. use with limit to get the next page of search results.
        /// </param>
        /// <param name="includeExternal">
        ///     If include_external=audio is specified it signals the client can play externally hosted audio content,
        ///     and marks the content as playable in the response. By default, externally hosted audio content is marked as unplayable.
        /// </param>
        /// <returns>
        ///     Returns Spotify catalog information about Albums, Artists, Playlists, Tracks, Shows, Episodes,
        ///     or Audiobooks that match a keyword string. Audiobooks are only available within the US, UK, Canada, Ireland,
        ///     New Zealand and Australia markets.
        /// </returns>
        [HttpGet]
        [Route("/Search")]
        [Produces(typeof(OkObjectResult))]
        public async Task<IActionResult> GetSearchAsync(
            [Required] string searchQuery,
            [Required] SearchType searchType,
            [Required] string marketCode,
            int? limit = null,
            int? offset = null,
            string? includeExternal = null)
        {
            var searchResult = await spotifyManager
                .GetSearchAsync(searchQuery, searchType, marketCode, limit, offset, includeExternal);

            return Ok(searchResult);
        }

        /// <summary>
        /// Retrieves Spotify catalog information for a single artist identified by their unique Spotify ID.
        /// </summary>
        /// <param name="artistId">The unique spotify artist id returned from GET Search</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/Artist")]
        [Produces(typeof(OkObjectResult))]
        public async Task<IActionResult> GetArtistAsync([Required] string artistId)
        {
            var artist = await spotifyManager
                .GetArtistAsync(artistId);

            return Ok(artist);
        }
    }
}
