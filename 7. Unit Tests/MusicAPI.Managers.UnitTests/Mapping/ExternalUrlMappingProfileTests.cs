namespace MusicAPI.Managers.UnitTests.Mapping
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ExternalUrlMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(ExternalUrlMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void ExternalUrlMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void ExternalUrl_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedUrl = "SpotifyTest";

            var externalUrlDTO = new Accessors.DataTransferObjects.ExternalUrl
            {
                Spotify = expectedUrl
            };

            // Act
            var externalUrlViewModel = Mapper.Map<ViewModels.ExternalUrl>(externalUrlDTO);

            // Assert
            Assert.That(externalUrlViewModel.Spotify, Is.EqualTo(expectedUrl));
        }
    }
}
