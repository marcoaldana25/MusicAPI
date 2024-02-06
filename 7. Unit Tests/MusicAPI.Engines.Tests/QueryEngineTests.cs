namespace MusicAPI.Engines.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class QueryEngineTests
    {
        [Test]
        public void BuildCurrentUserProfileQueryString_ShouldReturnQueryString()
        {
            // Arrange
            var queryEngine = new QueryEngine();

            // Act
            var queryString = queryEngine.BuildCurrentUserProfileQueryString();

            // Assert
            const string expectedQueryString = "https://api.spotify.com/v1/me";

            Assert.That(queryString, Is.EqualTo(expectedQueryString));
        }

        [Test]
        public void BuildSpotifySearchQueryString_OnlyRequiredParameters_ShouldReturnQueryString()
        {
            // Arrange
            var queryEngine = new QueryEngine();

            // Act
            var queryString = queryEngine
                .BuildSpotifySearchQueryString("Daft Punk", "Artist", "ES", null, null);

            // Assert
            var expectedQueryString = "https://api.spotify.com/v1/search?q=Daft Punk&type=artist&market=ES";

            Assert.That(queryString, Is.EqualTo(expectedQueryString));
        }

        [Test]
        public void BuildSpotifySearchQueryString_OverrideLimitAndOffset_ShouldReturnQueryString()
        {
            // Arrange
            var queryEngine = new QueryEngine();

            // Act
            var queryString = queryEngine
                .BuildSpotifySearchQueryString("Daft Punk", "Artist", "ES", 10, 1);

            // Assert
            var expectedQueryString = "https://api.spotify.com/v1/search?q=Daft Punk&type=artist&market=ES&limit=10&offset=1";

            Assert.That(queryString, Is.EqualTo(expectedQueryString));
        }

        [Test]
        public void BuildSpotifySearchQueryString_OptionalIncludeExternal_ShouldReturnQueryString()
        {
            // Arrange
            var queryEngine = new QueryEngine();

            // Act
            var queryString = queryEngine
                .BuildSpotifySearchQueryString("Daft Punk", "Artist", "ES", 20, 0, "audio");

            // Assert
            var expectedQueryString = "https://api.spotify.com/v1/search?q=Daft Punk&type=artist&market=ES&limit=20&offset=0&include_external=audio";

            Assert.That(queryString, Is.EqualTo(expectedQueryString));
        }

        [Test]
        public void BuildGetArtistQueryString_ShouldReturnQueryString()
        {
            // Arrange
            var queryEngine = new QueryEngine();

            // Act
            var queryString = queryEngine
                .BuildGetArtistQueryString("testId");

            // Assert
            const string expectedQueryString = "https://api.spotify.com/v1/artists/testId";

            Assert.That(queryString, Is.EqualTo(expectedQueryString));
        }

        [Test]
        public void BuildArtistTopTracksQueryString_ShouldReturnQueryString()
        {
            // Arrange
            var queryEngine = new QueryEngine();

            // Act
            var queryString = queryEngine
                .BuildArtistTopTracksQueryString("artistId", "marketCode");

            // Assert
            const string expectedQueryString = "https://api.spotify.com/v1/artists/artistId/top-tracks?market=marketCode";

            Assert.That(queryString, Is.EqualTo(expectedQueryString));
        }
    }
}
