namespace MusicAPI.Managers.Tests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RelatedArtistsMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(RelatedArtistsMappingProfile));
                configuration.AddProfile(typeof(ArtistMappingProfile));
                configuration.AddProfile(typeof(ExternalUrlMappingProfile));
                configuration.AddProfile(typeof(FollowersMappingProfile));
                configuration.AddProfile(typeof(ImageMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void RelatedArtistsMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void RelatedArtists_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            var relatedArtistsDataTransferObject = new Accessors.DataTransferObjects.RelatedArtists
            {
                Artists =
                [
                    new Accessors.DataTransferObjects.Artist()
                ]
            };

            // Act
            var relatedArtistsViewModel = Mapper.Map<ViewModels.RelatedArtists>(relatedArtistsDataTransferObject);

            // Assert
            Assert.That(relatedArtistsViewModel.Artists, Is.Not.Null);
        }
    }
}
