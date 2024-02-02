﻿using Moq;
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
            var mockAuthorizationAccessor = new Mock<IAuthorizationAccessor>(MockBehavior.Strict);
            mockAuthorizationAccessor
                .Setup(authorizationAccessor => authorizationAccessor.RequestAccessTokenAsync())
                .ReturnsAsync("Bearer Token");

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
            var mockAuthorizationAccessor = new Mock<IAuthorizationAccessor>(MockBehavior.Strict);
            mockAuthorizationAccessor
                .Setup(authorizationAccessor => authorizationAccessor.RequestAccessTokenAsync())
                .ReturnsAsync("Bearer Token");

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
    }
}