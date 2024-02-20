namespace MusicAPI.Managers.Tests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PlaylistMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(PlaylistMappingProfile));
                configuration.AddProfile(typeof(ExternalUrlMappingProfile));
                configuration.AddProfile(typeof(ImageMappingProfile));
                configuration.AddProfile(typeof(OwnerMappingProfile));
                configuration.AddProfile(typeof(FollowersMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void PlaylistMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void Playlist_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedDescription = "description";
            const string expectedHref = "href";
            const string expectedName = "name";
            const string expectedSnapshotId = "Snapshot id";
            const string expectedType = "type";
            const string expectedUri = "uri";

            var playlistDataTransferObject = new Accessors.DataTransferObjects.Playlist
            {
                Collaborative = true,
                Description = expectedDescription,
                ExternalUrls = new Accessors.DataTransferObjects.ExternalUrl(),
                Href = expectedHref,
                Images =
                [
                    new Accessors.DataTransferObjects.Image()
                ],
                Name = expectedName,
                Owner = new Accessors.DataTransferObjects.Owner(),
                Public = true,
                SnapshotId = expectedSnapshotId,
                Type = expectedType,
                Uri = expectedUri
            };

            // Act
            var playlistViewModel = Mapper.Map<ViewModels.Playlist>(playlistDataTransferObject);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(playlistViewModel.Collaborative, Is.True);
                Assert.That(playlistViewModel.Description, Is.EqualTo(expectedDescription));
                Assert.That(playlistViewModel.ExternalUrls, Is.Not.Null);
                Assert.That(playlistViewModel.Href, Is.EqualTo(expectedHref));
                Assert.That(playlistViewModel.Images, Is.Not.Null);
                Assert.That(playlistViewModel.Name, Is.EqualTo(expectedName));
                Assert.That(playlistViewModel.Owner, Is.Not.Null);
                Assert.That(playlistViewModel.Public, Is.True);
                Assert.That(playlistViewModel.SnapshotId, Is.EqualTo(expectedSnapshotId));
                Assert.That(playlistViewModel.Type, Is.EqualTo(expectedType));
                Assert.That(playlistViewModel.Uri, Is.EqualTo(expectedUri));
            });
        }
    }
}
