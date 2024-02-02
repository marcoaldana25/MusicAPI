using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using MusicAPI.Utilities.Interfaces;
using System.Net;


namespace MusicAPI.Accessors.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AuthorizationAccessorTests
    {
        private IMemoryCache _cache;

        [SetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();

            var serviceProvider = services.BuildServiceProvider();
            _cache = serviceProvider.GetRequiredService<IMemoryCache>();
        }

        [TearDown]
        public void TearDown()
        {
            _cache.Dispose();
        }

        [Test]
        public async Task RequestAccessTokenAsync_TokenStoredInCache_ShouldReturnInMemoryValue()
        {
            // Arrange
            const string expectedToken = "cachedToken";

            _cache.Set("SpotifyAccessToken", expectedToken, TimeSpan.FromSeconds(10));

            var mockConfigurationManager = new Mock<IConfigurationManager>(MockBehavior.Strict);
            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

            var authorizationAccessor = new AuthorizationAccessor(
                mockConfigurationManager.Object,
                mockHttpClientFactory.Object,
                _cache);

            // Act
            var token = await authorizationAccessor.RequestAccessTokenAsync();

            // Assert
            Assert.That(token, Is.EqualTo(expectedToken));
        }

        [Test]
        public async Task RequestAccessTokenAsync_UnsuccessfulResponseCode_ShouldReturnEmptyString()
        {
            // Arrange
            var mockConfigurationManager = GetMockConfigurationManager();

            var mockHttpClientFactory = GetMockHttpClientFactory(HttpStatusCode.BadRequest);

            var authorizationAccessor = new AuthorizationAccessor(
                mockConfigurationManager.Object,
                mockHttpClientFactory.Object,
                _cache);

            // Act
            var token = await authorizationAccessor
                .RequestAccessTokenAsync();

            // Assert
            Assert.That(token, Is.Empty);
        }

        [Test]
        public async Task RequestAccessToken_SuccessfulStatusCode_ShouldReturnAccessToken_AndCache()
        {
            // Arrange
            var mockConfigurationManager = GetMockConfigurationManager();

            const string expectedAccessToken = "Expected Access Token";

            var mockHttpClientFactory = GetMockHttpClientFactory(HttpStatusCode.OK, new SpotifyAccessToken
            {
                AccessToken = expectedAccessToken,
                ExpiresIn = 10,
                TokenType = "bearer"
            });

            var authorizationAccessor = new AuthorizationAccessor(
                mockConfigurationManager.Object,
                mockHttpClientFactory.Object,
                _cache);

            // Act
            var token = await authorizationAccessor
                .RequestAccessTokenAsync();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(token, Is.EqualTo(expectedAccessToken));

                var cachedToken = _cache.Get("SpotifyAccessToken");

                Assert.That(token, Is.EqualTo(cachedToken));
            });
        }

        private static Mock<IConfigurationManager> GetMockConfigurationManager()
        {
            var mockConfigurationManager = new Mock<IConfigurationManager>(MockBehavior.Strict);
            mockConfigurationManager
                .Setup(configurationManager => configurationManager.GetSpotifyClientId())
                .Returns("ClientId");

            mockConfigurationManager
                .Setup(configurationManager => configurationManager.GetSpotifyClientSecret())
                .Returns("ClientSecret");

            mockConfigurationManager
                .Setup(configurationManager => configurationManager.GetSpotifyAuthorizationCode())
                .Returns("AuthorizationCode");

            return mockConfigurationManager;
        }

        private static Mock<IHttpClientFactory> GetMockHttpClientFactory(HttpStatusCode statusCode, SpotifyAccessToken? accessToken = null)
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(JsonSerializer.Serialize(accessToken))
                });

            var mockHttpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);
            mockHttpClientFactory
                .Setup(httpClientFactory => httpClientFactory.CreateClient(string.Empty))
                .Returns(new HttpClient(mockHttpMessageHandler.Object));

            return mockHttpClientFactory; ;
        }
    }
}
