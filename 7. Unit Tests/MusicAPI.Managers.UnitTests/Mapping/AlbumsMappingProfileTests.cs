namespace MusicAPI.Managers.Tests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AlbumsMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(AlbumsMappingProfile));
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
        public void AlbumsMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void Albums_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedHref = "Albums Href";
            const decimal expectedLimit = 100;
            const string expectedNext = "Albums Next";
            const decimal expectedOffset = 10;
            const string expectedPrevious = "Albums Previous";
            const decimal expectedTotal = 1;

            var albumsDataTransferObject = new Accessors.DataTransferObjects.Albums
            {
                Href = expectedHref,
                Limit = expectedLimit,
                Next = expectedNext,
                Offset = expectedOffset,
                Previous = expectedPrevious,
                Total = expectedTotal,
                Items =
                [
                    new Accessors.DataTransferObjects.Album()
                ]
            };

            // Act
            var albumsViewModel = Mapper.Map<ViewModels.Albums>(albumsDataTransferObject);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(albumsViewModel.Href, Is.EqualTo(expectedHref));
                Assert.That(albumsViewModel.Limit, Is.EqualTo(expectedLimit));
                Assert.That(albumsViewModel.Next, Is.EqualTo(expectedNext));
                Assert.That(albumsViewModel.Offset, Is.EqualTo(expectedOffset));
                Assert.That(albumsViewModel.Previous, Is.EqualTo(expectedPrevious));
                Assert.That(albumsViewModel.Total, Is.EqualTo(expectedTotal));
                Assert.That(albumsViewModel.Items, Is.Not.Null);
            });
        }
    }
}
