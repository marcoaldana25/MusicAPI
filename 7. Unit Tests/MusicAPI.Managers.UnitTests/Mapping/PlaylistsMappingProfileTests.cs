namespace MusicAPI.Managers.Tests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PlaylistsMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(PlaylistsMappingProfile));
                configuration.AddProfile(typeof(PlaylistMappingProfile));
                configuration.AddProfile(typeof(ExternalUrlMappingProfile));
                configuration.AddProfile(typeof(ImageMappingProfile));
                configuration.AddProfile(typeof(OwnerMappingProfile));
                configuration.AddProfile(typeof(FollowersMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void PlaylistsMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void Playlists_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedPlaylistsHref = "Expected Playlists Href";
            const string expectedNext = "Expected Next";
            const string expectedPrevious = "Expected Previous";

            var playlistsDataTransferObject = new Accessors.DataTransferObjects.Playlists
            {
                Href = expectedPlaylistsHref,
                Limit = 1,
                Next = expectedNext,
                Offset = 2,
                Previous = expectedPrevious,
                Total = 3,
                Items =
                [
                    new Accessors.DataTransferObjects.Playlist()
                ]
            };

            // Act
            var playlistsViewModel = Mapper.Map<ViewModels.Playlists>(playlistsDataTransferObject);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(playlistsViewModel.Href, Is.EqualTo(expectedPlaylistsHref));
                Assert.That(playlistsViewModel.Limit, Is.EqualTo(1));
                Assert.That(playlistsViewModel.Next, Is.EqualTo(expectedNext));
                Assert.That(playlistsViewModel.Offset, Is.EqualTo(2));
                Assert.That(playlistsViewModel.Previous, Is.EqualTo(expectedPrevious));
                Assert.That(playlistsViewModel.Total, Is.EqualTo(3));
                Assert.That(playlistsViewModel.Items, Is.Not.Null);
            });
        }
    }
}
