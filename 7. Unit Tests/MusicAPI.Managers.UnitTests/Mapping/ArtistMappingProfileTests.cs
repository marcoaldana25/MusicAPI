namespace MusicAPI.Managers.Tests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ArtistMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(ArtistMappingProfile));
                configuration.AddProfile(typeof(ExternalUrlMappingProfile));
                configuration.AddProfile(typeof(FollowersMappingProfile));
                configuration.AddProfile(typeof(ImageMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void ArtistMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void Artist_DataTransferObject_To_ViewModel_ShoudMap()
        {
            // Arrange
            const string expectedExternalUrl = "Expected External Url";
            const string expectedFollowersHref = "Expected Followers Href";
            const string expectedGenre = "Expected Genre";
            const string expectedArtistHref = "Expected Artist Href";
            const string expectedArtistId = "Expected Artist Id";
            const string expectedImageUrl = "Expected Image Url";
            const string expectedArtistName = "Expected Artist Name";
            const string expectedArtistType = "Expected Artist Type";
            const string expectedArtistUri = "Expected Artist Uri";

            var artistDataTransferObject = new Accessors.DataTransferObjects.Artist
            {
                ExternalUrl = new Accessors.DataTransferObjects.ExternalUrl
                {
                    Spotify = expectedExternalUrl
                },
                Followers = new Accessors.DataTransferObjects.Followers
                {
                    Href = expectedFollowersHref,
                    Total = 10
                },
                Genres =
                [
                    expectedGenre
                ],
                Href = expectedArtistHref,
                Id = expectedArtistId,
                Images =
                [
                    new Accessors.DataTransferObjects.Image
                    {
                        Height = 100,
                        Width = 200,
                        Url = expectedImageUrl
                    }
                ],
                Name = expectedArtistName,
                Popularity = 1,
                Type = expectedArtistType,
                Uri = expectedArtistUri
            };

            // Act
            var artistViewModel = Mapper.Map<ViewModels.Artist>(artistDataTransferObject);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(artistViewModel.ExternalUrl.Spotify, Is.EqualTo(expectedExternalUrl));
                Assert.That(artistViewModel.Followers.Href, Is.EqualTo(expectedFollowersHref));
                Assert.That(artistViewModel.Followers.Total, Is.EqualTo(10));
                Assert.That(artistViewModel.Genres[0], Is.EqualTo(expectedGenre));
                Assert.That(artistViewModel.Href , Is.EqualTo(expectedArtistHref));
                Assert.That(artistViewModel.Id, Is.EqualTo(expectedArtistId));
                Assert.That(artistViewModel.Images[0].Height, Is.EqualTo(100));
                Assert.That(artistViewModel.Images[0].Width, Is.EqualTo(200));
                Assert.That(artistViewModel.Images[0].Url, Is.EqualTo(expectedImageUrl));
                Assert.That(artistViewModel.Name, Is.EqualTo(expectedArtistName));
                Assert.That(artistViewModel.Popularity, Is.EqualTo(1));
                Assert.That(artistViewModel.Type, Is.EqualTo(expectedArtistType));
                Assert.That(artistViewModel.Uri, Is.EqualTo(expectedArtistUri));
            });
        }
    }
}
