namespace MusicAPI.Managers.Tests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ArtistsMappingProfileTests
    {
        private IMapper Mapper;

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(ArtistsMappingProfile));
                configuration.AddProfile(typeof(ArtistMappingProfile));
                configuration.AddProfile(typeof(ExternalUrlMappingProfile));
                configuration.AddProfile(typeof(FollowersMappingProfile));
                configuration.AddProfile(typeof(ImageMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void ArtistsMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void Artists_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedArtistsHref = "Expected Artists Href";
            const string expectedNext = "Expected Next";
            const string expectedPrevious = "Expected Previous";
            const string expectedArtistId = "Expected Artist Id";

            var artistsDataTransferObject = new Accessors.DataTransferObjects.Artists
            {
                Href = expectedArtistsHref,
                Limit = 1,
                Next = expectedNext,
                Offset = 2,
                Previous = expectedPrevious,
                Total = 3,
                Items =
                [
                    new Accessors.DataTransferObjects.Artist
                    {
                        Id = expectedArtistId
                    }
                ]
            };

            // Act
            var artistsViewModel = Mapper.Map<ViewModels.Artists>(artistsDataTransferObject);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(artistsViewModel.Href, Is.EqualTo(expectedArtistsHref));
                Assert.That(artistsViewModel.Limit, Is.EqualTo(1));
                Assert.That(artistsViewModel.Next, Is.EqualTo(expectedNext));
                Assert.That(artistsViewModel.Offset, Is.EqualTo(2));
                Assert.That(artistsViewModel.Previous, Is.EqualTo(expectedPrevious));
                Assert.That(artistsViewModel.Total, Is.EqualTo(3));
                Assert.That(artistsViewModel.Items[0].Id, Is.EqualTo(expectedArtistId));
            });
        }
    }
}
