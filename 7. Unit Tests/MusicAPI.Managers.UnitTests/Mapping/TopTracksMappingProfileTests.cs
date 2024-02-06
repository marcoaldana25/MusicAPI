namespace MusicAPI.Managers.Tests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TopTracksMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(TopTracksMappingProfile));
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
        public void TopTracksMappingProfile_AsserConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void TopTracks_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            var topTracksDataTransferObject = new Accessors.DataTransferObjects.TopTracks
            {
                Tracks =
                [
                    new Accessors.DataTransferObjects.Track()
                ]
            };

            // Act
            var topTracksViewModel = Mapper.Map<ViewModels.TopTracks>(topTracksDataTransferObject);

            // Assert
            Assert.IsNotNull(topTracksViewModel.Tracks);
        }
    }
}
