using Moq;
using MusicAPI.Accessors.Interfaces;
using MusicAPI.Engines.Interfaces;

namespace MusicAPI.Managers.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SpotifyManagerTests
    {
        [Test]
        public async Task GetSpotifyAccoutnAsync_ShouldReturnUserProfile()
        {
            // Arrange
            var mockAuthorizationAccessor = GetMockAuthorizationAccessor();

            var mockQueryEngine = new Mock<IQueryEngine>(MockBehavior.Strict);
            mockQueryEngine
                .Setup(queryEngine => queryEngine.BuildCurrentUserProfileQueryString())
                .Returns("http://localhost");

            var mockSpotifyAccessor = new Mock<ISpotifyAccessor>(MockBehavior.Strict);
            mockSpotifyAccessor
                .Setup(spotifyAccessor => spotifyAccessor.GetCurrentUserProfileAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new Accessors.DataTransferObjects.UserProfile());

            var mockMapper = new Mock<IMapper>(MockBehavior.Strict);
            mockMapper
                .Setup(mapper => mapper.Map<ViewModels.UserProfile>(It.IsAny<Accessors.DataTransferObjects.UserProfile>()))
                .Returns(new ViewModels.UserProfile());

            var spotifyManager = new SpotifyManager(
                mockAuthorizationAccessor.Object,
                mockMapper.Object,
                mockSpotifyAccessor.Object,
                mockQueryEngine.Object);

            // Act
            var userProfile = await spotifyManager
                .GetSpotifyAccountAsync();

            // Assert/Verify
            mockSpotifyAccessor
                .Verify(spotifyAccessor => 
                    spotifyAccessor.GetCurrentUserProfileAsync(
                        It.Is<string>(bearerToken => bearerToken.Equals("Bearer Token")),
                        It.Is<string>(queryString => queryString.Equals("http://localhost"))),
                    Times.Once);
        }

        [Test]
        public async Task GetSearchAsync_ShouldReturnSearchResult()
        {
            // Arrange
            var mockAuthorizationAccessor = GetMockAuthorizationAccessor();

            var mockQueryEngine = new Mock<IQueryEngine>(MockBehavior.Strict);
            mockQueryEngine
                .Setup(queryEngine => queryEngine.BuildSpotifySearchQueryString(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<int?>(),
                    It.IsAny<int?>(),
                    It.IsAny<string?>()))
                .Returns("http://localhost");

            var mockSpotifyAccessor = new Mock<ISpotifyAccessor>(MockBehavior.Strict);
            mockSpotifyAccessor
                .Setup(spotifyAccessor => spotifyAccessor.GetSearchAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new Accessors.DataTransferObjects.SearchResult());

            var mockMapper = new Mock<IMapper>(MockBehavior.Strict);
            mockMapper
                .Setup(mapper => mapper.Map<ViewModels.SearchResult>(It.IsAny<Accessors.DataTransferObjects.SearchResult>()))
                .Returns(new ViewModels.SearchResult());

            var spotifyManager = new SpotifyManager(
                mockAuthorizationAccessor.Object,
                mockMapper.Object,
                mockSpotifyAccessor.Object,
                mockQueryEngine.Object);

            // Act
            var searchResult = await spotifyManager
                .GetSearchAsync(
                    "search", 
                    ViewModels.Enums.SearchType.Artist, 
                    "ES");

            // Assert/Verify
            mockSpotifyAccessor
                .Verify(spotifyAccessor =>
                    spotifyAccessor.GetSearchAsync(
                        It.Is<string>(bearerToken => bearerToken.Equals("Bearer Token")),
                        It.Is<string>(queryString => queryString.Equals("http://localhost"))),
                    Times.Once);
        }

        [Test]
        public async Task GetArtistAsync_ShouldReturnArtist()
        {
            // Arrange
            var mockAuthorizationAccessor = GetMockAuthorizationAccessor();

            var mockQueryEngine = new Mock<IQueryEngine>(MockBehavior.Strict);
            mockQueryEngine
                .Setup(queryEngine => queryEngine.BuildGetArtistQueryString(
                    It.IsAny<string>()))
                .Returns("http://localhost");

            var mockSpotifyAccessor = new Mock<ISpotifyAccessor>(MockBehavior.Strict);
            mockSpotifyAccessor
                .Setup(spotifyAccessor => spotifyAccessor.GetArtistAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new Accessors.DataTransferObjects.Artist());

            var mockMapper = new Mock<IMapper>(MockBehavior.Strict);
            mockMapper
                .Setup(mapper => mapper.Map<ViewModels.Artist>(It.IsAny<Accessors.DataTransferObjects.Artist>()))
                .Returns(new ViewModels.Artist());

            var spotifyManager = new SpotifyManager(
                mockAuthorizationAccessor.Object,
                mockMapper.Object,
                mockSpotifyAccessor.Object,
                mockQueryEngine.Object);

            // Act
            var artist = await spotifyManager
                .GetArtistAsync("artistId");

            // Assert/Verify
            mockSpotifyAccessor
                .Verify(spotifyAccessor =>
                    spotifyAccessor.GetArtistAsync(
                        It.Is<string>(bearerToken => bearerToken.Equals("Bearer Token")),
                        It.Is<string>(queryString => queryString.Equals("http://localhost"))),
                    Times.Once);
        }

        [Test]
        public async Task GetArtistTopTracksAsync_ShouldReturnTopTracks()
        {
            // Arrange
            var mockAuthorizationAccessor = GetMockAuthorizationAccessor();

            var mockQueryEngine = new Mock<IQueryEngine>(MockBehavior.Strict);
            mockQueryEngine
                .Setup(queryEngine => queryEngine.BuildArtistTopTracksQueryString(
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns("http://localhost");

            var mockSpotifyAccessor = new Mock<ISpotifyAccessor>(MockBehavior.Strict);
            mockSpotifyAccessor
                .Setup(spotifyAccessor => spotifyAccessor.GetTopTracksAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new Accessors.DataTransferObjects.TopTracks());

            var mockMapper = new Mock<IMapper>(MockBehavior.Strict);
            mockMapper
                .Setup(mapper => mapper.Map<ViewModels.TopTracks>(It.IsAny<Accessors.DataTransferObjects.TopTracks>()))
                .Returns(new ViewModels.TopTracks());

            var spotifyManager = new SpotifyManager(
                mockAuthorizationAccessor.Object,
                mockMapper.Object,
                mockSpotifyAccessor.Object,
                mockQueryEngine.Object);

            // Act
            var topTracks = await spotifyManager
                .GetArtistTopTracksAsync("artistId", "marketCode");

            // Assert
            mockSpotifyAccessor
                .Verify(
                    spotifyAccessor => spotifyAccessor.GetTopTracksAsync(
                        It.Is<string>(bearerToken => bearerToken.Equals("Bearer Token")),
                        It.Is<string>(queryString => queryString.Equals("http://localhost"))),
                    Times.Once());
        }

        [Test]
        public async Task GetAlbumsAsync_ShouldReturnAlbums()
        {
            // Arrange
            var mockAuthorizationAccessor = GetMockAuthorizationAccessor();

            var mockQueryEngine = new Mock<IQueryEngine>(MockBehavior.Strict);
            mockQueryEngine
                .Setup(queryEngine => queryEngine.BuildArtistAlbumsQueryString(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string?>(),
                    It.IsAny<int?>(),
                    It.IsAny<int?>()))
                .Returns("http://localhost");

            var mockSpotifyAccessor = new Mock<ISpotifyAccessor>(MockBehavior.Strict);
            mockSpotifyAccessor
                .Setup(spotifyAccessor => spotifyAccessor.GetArtistAlbumsAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new Accessors.DataTransferObjects.Albums());

            var mockMapper = new Mock<IMapper>(MockBehavior.Strict);
            mockMapper
                .Setup(mapper => mapper.Map<ViewModels.Albums>(It.IsAny<Accessors.DataTransferObjects.Albums>()))
                .Returns(new ViewModels.Albums());

            var spotifyManager = new SpotifyManager(
                mockAuthorizationAccessor.Object,
                mockMapper.Object,
                mockSpotifyAccessor.Object,
                mockQueryEngine.Object);

            // Act
            var albums = await spotifyManager
                .GetAlbumsAsync("artistId", "marketCode");

            // Assert
            mockSpotifyAccessor
                .Verify(
                    spotifyAccessor => spotifyAccessor.GetArtistAlbumsAsync(
                        It.Is<string>(bearerToken => bearerToken.Equals("Bearer Token")),
                        It.Is<string>(queryString => queryString.Equals("http://localhost"))),
                    Times.Once());
        }

        [Test]
        public async Task GetRelatedArtistsAsync_ShouldReturnRelatedArtists()
        {
            // Arrange
            var mockAuthorizationAccessor = GetMockAuthorizationAccessor();

            var mockQueryEngine = new Mock<IQueryEngine>(MockBehavior.Strict);
            mockQueryEngine
                .Setup(queryEngine => queryEngine.BuildRelatedArtistsQueryString(
                    It.IsAny<string>()))
                .Returns("http://localhost");

            var mockSpotifyAccessor = new Mock<ISpotifyAccessor>(MockBehavior.Strict);
            mockSpotifyAccessor
                .Setup(spotifyAccessor => spotifyAccessor.GetRelatedArtistsAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new Accessors.DataTransferObjects.RelatedArtists());

            var mockMapper = new Mock<IMapper>(MockBehavior.Strict);
            mockMapper
                .Setup(mapper => mapper.Map<ViewModels.RelatedArtists>(It.IsAny<Accessors.DataTransferObjects.RelatedArtists>()))
                .Returns(new ViewModels.RelatedArtists());

            var spotifyManager = new SpotifyManager(
                mockAuthorizationAccessor.Object,
                mockMapper.Object,
                mockSpotifyAccessor.Object,
                mockQueryEngine.Object);

            // Act
            var relatedArtists = await spotifyManager
                .GetRelatedArtistsAsync("artistId");

            // Assert
            mockSpotifyAccessor
                .Verify(
                    spotifyAccessor => spotifyAccessor.GetRelatedArtistsAsync(
                        It.Is<string>(bearerToken => bearerToken.Equals("Bearer Token")),
                        It.Is<string>(queryString => queryString.Equals("http://localhost"))),
                    Times.Once());
        }

        private static Mock<IAuthorizationAccessor> GetMockAuthorizationAccessor()
        {
            var mockAuthorizationAccessor = new Mock<IAuthorizationAccessor>(MockBehavior.Strict);
            mockAuthorizationAccessor
                .Setup(authorizationAccessor => authorizationAccessor.RequestAccessTokenAsync())
                .ReturnsAsync("Bearer Token");

            return mockAuthorizationAccessor;
        }
    }
}
