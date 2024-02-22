namespace MusicAPI.Managers.Tests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TracksMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(TracksMappingProfile));
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
        public void Tracks_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedHref = "Tracks Href";
            const decimal expectedLimit = 100;
            const string expectedNext = "Tracks Next";
            const decimal expectedOffset = 10;
            const string expectedPrevious = "Tracks Previous";
            const decimal expectedTotal = 1;

            var tracksDataTransferObject = new Accessors.DataTransferObjects.Tracks
            {
                Href = expectedHref,
                Limit = expectedLimit,
                Next = expectedNext,
                Offset = expectedOffset,
                Previous = expectedPrevious,
                Total = expectedTotal,
                Items =
                [
                    new Accessors.DataTransferObjects.Track()
                ]
            };

            // Act
            var tracksViewModel = Mapper.Map<ViewModels.Tracks>(tracksDataTransferObject);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(tracksViewModel.Href, Is.EqualTo(expectedHref));
                Assert.That(tracksViewModel.Limit, Is.EqualTo(expectedLimit));
                Assert.That(tracksViewModel.Next, Is.EqualTo(expectedNext));
                Assert.That(tracksViewModel.Offset, Is.EqualTo(expectedOffset));
                Assert.That(tracksViewModel.Previous, Is.EqualTo(expectedPrevious));
                Assert.That(tracksViewModel.Total, Is.EqualTo(expectedTotal));
                Assert.That(tracksViewModel.Items, Is.Not.Null);
            });
        }
    }
}
