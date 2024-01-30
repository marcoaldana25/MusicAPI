using Moq;
using Moq.Protected;
using MusicAPI.Accessors.DataTransferObjects;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

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
            .GetCurrentUserProfileAsync(string.Empty));

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
                .GetCurrentUserProfileAsync("bearer"));
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
                .GetCurrentUserProfileAsync("bearer");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Country, Is.EqualTo(expectedCountry));
                Assert.That(result.DisplayName, Is.EqualTo(expectedDisplayName));
            });
        }
    }
}
