namespace MusicAPI.Accessors.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SpotifyAccessorTests
    {
        [Test]
        public void GetCurrentUserProfileAsync_EmptyBearerToken_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            var spotifyAccessor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await spotifyAccessor
                .GetCurrentUserProfileAsync(string.Empty, string.Empty));

        }

        [Test]
        public void GetCurrentUserProfileAsync_EmptyQueryString_ShouldthrowArgumentNullException()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            var spotifyAccessor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await spotifyAccessor
                .GetCurrentUserProfileAsync("bearer", string.Empty));

        }

        [Test]
        public void GetCurrentUserProfileAsync_InvalidResponseCode_ShouldThrowHttpRequestException()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };

            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);

            mockHttpClientFactory
                .Setup(httpClientFactory => httpClientFactory.CreateClient(string.Empty))
                .Returns(new HttpClient(mockHttpMessageHandler.Object))
                .Verifiable();

            var spotifyAccessor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act & Assert
            Assert.ThrowsAsync<HttpRequestException>(async () => await spotifyAccessor
                .GetCurrentUserProfileAsync("bearer", "http://localhost/"));
        }

        [Test]
        public async Task GetCurrentUserProfileAsync_SuccessfulResponseCode_ShouldReturnUserProfile()
        {
            // Arrange
            var expectedCountry = "USA";
            var expectedDisplayName = "Successful Test";

            var expectedUserProfile = new UserProfile
            {
                Country = expectedCountry,
                DisplayName = expectedDisplayName
            };

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedUserProfile))
            };

            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);

            mockHttpClientFactory
                .Setup(httpClientFactory => httpClientFactory.CreateClient(string.Empty))
                .Returns(new HttpClient(mockHttpMessageHandler.Object));

            var spotifyAccessor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act
            var result = await spotifyAccessor
                .GetCurrentUserProfileAsync("bearer", "http://localhost");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Country, Is.EqualTo(expectedCountry));
                Assert.That(result.DisplayName, Is.EqualTo(expectedDisplayName));
            });
        }

        [Test]
        public void GetSearchAsync_EmptyBearerToken_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            var spotifyAccesor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => 
                await spotifyAccesor.GetSearchAsync(string.Empty, string.Empty));
        }

        [Test]
        public void GetSearchAsync_EmptyQueryString_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            var spotifyAccessor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await spotifyAccessor.GetSearchAsync("bearerToken", string.Empty));
        }

        [Test]
        public void GetSearchAsync_UnsuccessfulStatusCode_ShouldThrowHttpRequestException()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });

            mockHttpClientFactory
                .Setup(httpClientFactory => httpClientFactory.CreateClient(string.Empty))
                .Returns(new HttpClient(mockHttpMessageHandler.Object));

            var spotifyAccessor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act & Assert
            Assert.ThrowsAsync<HttpRequestException>(async () =>
                await spotifyAccessor.GetSearchAsync("bearer", "http://localhost"));
        }

        [Test]
        public async Task GetSearchAsync_SuccessfulStatusCode_ShouldReturnSearchResult()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            var expectedSearchResult = new SearchResult
            {
                Artists = new Artists
                {
                    Total = 1
                }
            };

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize(expectedSearchResult))
                });

            mockHttpClientFactory
                .Setup(httpClientFactory => httpClientFactory.CreateClient(string.Empty))
                .Returns(new HttpClient(mockHttpMessageHandler.Object));

            var spotifyAccessor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act
            var result = await spotifyAccessor
                .GetSearchAsync("bearer", "http://localhost");

            // Assert
            Assert.That(result.Artists.Total, Is.EqualTo(expectedSearchResult.Artists.Total));
        }

        [Test]
        public void GetArtistAsync_EmptyBearerToken_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            var spotifyAccesor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await spotifyAccesor.GetArtistAsync(string.Empty, string.Empty));
        }

        [Test]
        public void GetArtistAsync_EmptyQueryString_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            var spotifyAccessor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await spotifyAccessor.GetArtistAsync("bearerToken", string.Empty));
        }

        [Test]
        public void GetArtistAsync_UnsuccessfulStatusCode_ShouldThrowHttpRequestException()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });

            mockHttpClientFactory
                .Setup(httpClientFactory => httpClientFactory.CreateClient(string.Empty))
                .Returns(new HttpClient(mockHttpMessageHandler.Object));

            var spotifyAccessor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act & Assert
            Assert.ThrowsAsync<HttpRequestException>(async () =>
                await spotifyAccessor.GetArtistAsync("bearer", "http://localhost"));
        }

        [Test]
        public async Task GetArtistAsync_SuccessfulStatusCode_ShouldReturnSearchResult()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            const string expectedArtistId = "Expected Artist Id";
            var expectedArtist = new Artist
            {
                Id = expectedArtistId
            };

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize(expectedArtist))
                });

            mockHttpClientFactory
                .Setup(httpClientFactory => httpClientFactory.CreateClient(string.Empty))
                .Returns(new HttpClient(mockHttpMessageHandler.Object));

            var spotifyAccessor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act
            var result = await spotifyAccessor
                .GetArtistAsync("bearer", "http://localhost");

            // Assert
            Assert.That(result.Id, Is.EqualTo(expectedArtistId));
        }

        [Test]
        public void GetTopTracksAsync_EmptyBearerToken_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            var spotifyAccesor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await spotifyAccesor.GetTopTracksAsync(string.Empty, string.Empty));
        }

        [Test]
        public void GetTopTracksAsync_EmptyQueryString_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            var spotifyAccessor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await spotifyAccessor.GetTopTracksAsync("bearerToken", string.Empty));
        }

        [Test]
        public void GetTopTracksAsync_UnsuccessfulStatusCode_ShouldThrowHttpRequestException()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });

            mockHttpClientFactory
                .Setup(httpClientFactory => httpClientFactory.CreateClient(string.Empty))
                .Returns(new HttpClient(mockHttpMessageHandler.Object));

            var spotifyAccessor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act & Assert
            Assert.ThrowsAsync<HttpRequestException>(async () =>
                await spotifyAccessor.GetTopTracksAsync("bearer", "http://localhost"));
        }

        [Test]
        public async Task GetTopTracksAsync_SuccessfulStatusCode_ShouldReturnTopTracks()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            const string expectedTrackHref = "Expected Track Href";

            var expectedTopTracks = new TopTracks
            {
                Tracks =
                [
                    new Track
                    {
                        Href = expectedTrackHref
                    }
                ]
            };

            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize(expectedTopTracks))
                });

            mockHttpClientFactory
                .Setup(httpClientFactory => httpClientFactory.CreateClient(string.Empty))
                .Returns(new HttpClient(mockHttpMessageHandler.Object));

            var spotifyAccessor = new SpotifyAccessor(mockHttpClientFactory.Object);

            // Act
            var topTracks = await spotifyAccessor
                .GetTopTracksAsync("bearer", "http://localhost");

            // Assert
            Assert.That(topTracks.Tracks[0].Href, Is.EqualTo(expectedTrackHref));
        }
    }
}
