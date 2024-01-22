using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace MusicAPI.Utilities.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ConfigurationManagerTests
    {
        private IConfiguration _configuration;

        [SetUp]
        public void SetUp()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        [Test]
        public void GetSpotifyClientId_ShouldReturnValueFromAppsettings()
        {
            // Arrange
            var configurationManager = new ConfigurationManager(_configuration);

            // Act
            var result = configurationManager
                .GetSpotifyClientId();

            // Assert
            const string expectedClientId = "SpotifyClientId";

            Assert.That(expectedClientId.Equals(result));
        }

        [Test]
        public void GetSpotifyClientSecret_ShouldReturnValueFromAppsettings()
        {
            // Arrange
            var configurationManager = new ConfigurationManager(_configuration);

            // Act
            var result = configurationManager
                .GetSpotifyClientSecret();

            // Assert
            const string expectedClientSecret = "SpotifyClientSecret";

            Assert.That(expectedClientSecret.Equals(result));
        }

        [Test]
        public void GetSpotifyAuthorizationCode_ShouldReturnValueFromAppsettings()
        {
            // Arrange
            var configurationManager = new ConfigurationManager(_configuration);

            // Act
            var result = configurationManager
                .GetSpotifyAuthorizationCode();

            // Assert
            const string expectedAuthCode = "SpotifyAuthCode";

            Assert.That(expectedAuthCode.Equals(result));
        }
    }
}
