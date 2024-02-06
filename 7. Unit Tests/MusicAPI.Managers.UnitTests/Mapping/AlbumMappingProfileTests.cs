namespace MusicAPI.Managers.Tests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AlbumMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(AlbumMappingProfile));
                configuration.AddProfile(typeof(ExternalUrlMappingProfile));
                configuration.AddProfile(typeof(ImageMappingProfile));
                configuration.AddProfile(typeof(RestrictionMappingProfile));
                configuration.AddProfile(typeof(ArtistMappingProfile));
                configuration.AddProfile(typeof(FollowersMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void AlbumMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void Album_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedAlbumType = "Expected Album Type";
            const decimal expectedTotalTracks = 10;
            const string expectedAvailableMarket = "ES";
            const string expectedExternalUrl = "Spotify";
            const string expectedAlbumHref = "Album Href";
            const string expectedAlbumId = "Album ID";
            const string expectedImageUrl = "Image Url";
            const int expectedImageHeight = 100;
            const int expectedImageWidth = 200;
            const string expectedAlbumName = "Album Name";
            const string expectedReleaseDate = "Release Date";
            const string expectedReleaseDatePrecision = "Release Date Precision";
            const string expectedRestrictionReason = "Restriction Reason";
            const string expectedType = "Album Type";
            const string expectedUri = "Album Uri";
            const string expectedArtistId = "Artist Id";


            var albumDataTransferObject = new Accessors.DataTransferObjects.Album
            {
                AlbumType = expectedAlbumType,
                TotalTracks = expectedTotalTracks,
                AvailableMarkets =
                [
                    expectedAvailableMarket
                ],
                ExternalUrls = new Accessors.DataTransferObjects.ExternalUrl
                {
                    Spotify = expectedExternalUrl
                },
                Href = expectedAlbumHref,
                Id = expectedAlbumId,
                Images =
                [
                    new Accessors.DataTransferObjects.Image
                    {
                        Url = expectedImageUrl,
                        Height = expectedImageHeight,
                        Width = expectedImageWidth
                    }
                ],
                Name = expectedAlbumName,
                ReleaseDate = expectedReleaseDate,
                ReleaseDatePrecision = expectedReleaseDatePrecision,
                Restrictions = new Accessors.DataTransferObjects.Restriction
                {
                    Reason = expectedRestrictionReason
                },
                Type = expectedType,
                Uri = expectedUri,
                Artists =
                [
                    new Accessors.DataTransferObjects.Artist
                    {
                        Id = expectedArtistId
                    }
                ]
            };

            // Act
            var albumViewModel = Mapper.Map<ViewModels.Album>(albumDataTransferObject);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(albumViewModel.AlbumType, Is.EqualTo(expectedAlbumType));
                Assert.That(albumViewModel.TotalTracks, Is.EqualTo(expectedTotalTracks));
                Assert.That(albumViewModel.AvailableMarkets[0], Is.EqualTo(expectedAvailableMarket));
                Assert.That(albumViewModel.ExternalUrls.Spotify, Is.EqualTo(expectedExternalUrl));
                Assert.That(albumViewModel.Href, Is.EqualTo(expectedAlbumHref));
                Assert.That(albumViewModel.Id, Is.EqualTo(expectedAlbumId));
                Assert.That(albumViewModel.Images[0].Url, Is.EqualTo(expectedImageUrl));
                Assert.That(albumViewModel.Images[0].Height, Is.EqualTo(expectedImageHeight));
                Assert.That(albumViewModel.Images[0].Width, Is.EqualTo(expectedImageWidth));
                Assert.That(albumViewModel.Name, Is.EqualTo(expectedAlbumName));
                Assert.That(albumViewModel.ReleaseDate, Is.EqualTo(expectedReleaseDate));
                Assert.That(albumViewModel.ReleaseDatePrecision, Is.EqualTo(expectedReleaseDatePrecision));
                Assert.That(albumViewModel.Restrictions.Reason, Is.EqualTo(expectedRestrictionReason));
                Assert.That(albumViewModel.Type, Is.EqualTo(expectedType));
                Assert.That(albumViewModel.Uri, Is.EqualTo(expectedUri));
                Assert.That(albumViewModel.Artists[0].Id, Is.EqualTo(expectedArtistId));
            });
        }
    }
}
