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
            int? limit = 20,
            int? offset = 0,
            string? includeExternal = "")
        {
            // Base request string using Required parameters
            var requestString = $"{SpotifyBaseUri}/search?q={searchQuery}" +
                $"&type={searchType.ToLower()}" +
                $"&market={marketCode.ToUpper()}";

            // Optionally add additional parameters to query string if present.
            if (limit != null)
            {
                requestString += $"&limit={limit}";
            }

            if (offset != null)
            {
                requestString += $"&offset={offset}";
            }

            if (!string.IsNullOrWhiteSpace(includeExternal))
            {
                requestString += $"&include_external={includeExternal}";
            }

            return requestString;
        }
    }
}
