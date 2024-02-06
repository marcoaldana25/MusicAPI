using MusicAPI.Engines.Interfaces;

namespace MusicAPI.Engines
{
    public class QueryEngine : IQueryEngine
    {
        private const string SpotifyBaseUri = "https://api.spotify.com/v1";

        public string BuildCurrentUserProfileQueryString()
        {
            return $"{SpotifyBaseUri}/me";
        }

        public string BuildSpotifySearchQueryString(
            string searchQuery,
            string searchType,
            string marketCode,
            int? limit,
            int? offset,
            string? includeExternal = "")
        {
            // Base request string using Required parameters/Parameters that are defaulted
            var requestString = $"{SpotifyBaseUri}/search?q={searchQuery}" +
                $"&type={searchType.ToLower()}" +
                $"&market={marketCode.ToUpper()}";

            
            if (limit != null)
            {
                requestString += $"&limit={limit}";
            }

            if (offset != null)
            {
                requestString += $"&offset={offset}";
            }

            // Optionally add additional parameters to query string if present.
            if (!string.IsNullOrWhiteSpace(includeExternal))
            {
                requestString += $"&include_external={includeExternal}";
            }

            return requestString;
        }

        public string BuildGetArtistQueryString(string artistId)
        {
            return $"{SpotifyBaseUri}/artists/{artistId}";
        }

        public string BuildArtistTopTracksQueryString(string artistId, string marketCode)
        {
            return $"{SpotifyBaseUri}/artists/{artistId}/top-tracks?market={marketCode}";
        }

        public string BuildArtistAlbumsQueryString(
            string artistId,
            string marketCode,
            string? includeGroups,
            int? limit,
            int? offset)
        {
            var requestString = $"{SpotifyBaseUri}/artists/{artistId}/albums?market={marketCode}";

            if (!string.IsNullOrWhiteSpace(includeGroups))
            {
                requestString += $"&include_groups={includeGroups}";
            }

            if (limit != null)
            {
                requestString += $"&limit={limit}";
            }

            if (offset != null)
            {
                requestString += $"&offset={offset}";
            }

            return requestString;
        }
    }
}
