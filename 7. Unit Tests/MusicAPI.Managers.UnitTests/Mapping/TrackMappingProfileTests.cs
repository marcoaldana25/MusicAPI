namespace MusicAPI.Managers.Tests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TrackMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(TrackMappingProfile));
                configuration.AddProfile(typeof(AlbumMappingProfile));
                configuration.AddProfile(typeof(ArtistMappingProfile));
                configuration.AddProfile(typeof(ExternalIdMappingProfile));
                configuration.AddProfile(typeof(ExternalUrlMappingProfile));
                configuration.AddProfile(typeof(RestrictionMappingProfile));
                configuration.AddProfile(typeof(ImageMappingProfile));
                configuration.AddProfile(typeof(FollowersMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void TrackMappingProfile_AsserConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void Track_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedAvailableMarket = "ES";
            const int expectedDiscNumber = 1;
            const decimal expectedDurationInMilliseconds = 1000;
            const string expectedTrackHref = "Track Href";
            const string expectedTrackId = "Track ID";
            const string expectedTrackName = "Track Name";
            const decimal expectedPopularity = 100;
            const string expectedPreviewUrl = "Preview Url";
            const decimal expectedTrackNumber = 1;
            const string expectedTrackType = "Track Type";
            const string expectedTrackUri = "Track Uri";

            var trackDataTransferObject = new Accessors.DataTransferObjects.Track
            {
                Album = new Accessors.DataTransferObjects.Album(),
                Artists =
                [
                    new Accessors.DataTransferObjects.Artist()
                ],
                AvailableMarkets =
                [
                    expectedAvailableMarket
                ],
                DiscNumber = expectedDiscNumber,
                DurationInMilliseconds = expectedDurationInMilliseconds,
                IsExplicit = true,
                ExternalIds = new Accessors.DataTransferObjects.ExternalId(),
                ExternalUrls = new Accessors.DataTransferObjects.ExternalUrl(),
                Href = expectedTrackHref,
                Id = expectedTrackId,
                IsPlayable = true,
                Restrictions = new Accessors.DataTransferObjects.Restriction(),
                Name = expectedTrackName,
                Popularity = expectedPopularity,
                PreviewUrl = expectedPreviewUrl,
                TrackNumber = expectedTrackNumber,
                Type = expectedTrackType,
                Uri = expectedTrackUri,
                IsLocal = true
            };

            // Act
            var trackViewModel = Mapper.Map<ViewModels.Track>(trackDataTransferObject);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(trackViewModel.Album);
                Assert.IsNotNull(trackViewModel.Artists);
                Assert.That(trackViewModel.AvailableMarkets[0], Is.EqualTo(expectedAvailableMarket));
                Assert.That(trackViewModel.DiscNumber, Is.EqualTo(expectedDiscNumber));
                Assert.That(trackViewModel.DurationInMilliseconds, Is.EqualTo(expectedDurationInMilliseconds));
                Assert.That(trackViewModel.IsExplicit, Is.True);
                Assert.IsNotNull(trackViewModel.ExternalIds);
                Assert.IsNotNull(trackViewModel.ExternalUrls);
                Assert.That(trackViewModel.Href, Is.EqualTo(expectedTrackHref));
                Assert.That(trackViewModel.Id, Is.EqualTo(expectedTrackId));
                Assert.That(trackViewModel.IsPlayable, Is.True);
                Assert.IsNotNull(trackViewModel.Restrictions);
                Assert.That(trackViewModel.Name, Is.EqualTo(expectedTrackName));
                Assert.That(trackViewModel.Popularity, Is.EqualTo(expectedPopularity));
                Assert.That(trackViewModel.PreviewUrl, Is.EqualTo(expectedPreviewUrl));
                Assert.That(trackViewModel.TrackNumber, Is.EqualTo(expectedTrackNumber));
                Assert.That(trackViewModel.Type, Is.EqualTo(expectedTrackType));
                Assert.That(trackViewModel.Uri, Is.EqualTo(expectedTrackUri));
                Assert.That(trackViewModel.IsLocal, Is.True);
            });
        }
    }
}
