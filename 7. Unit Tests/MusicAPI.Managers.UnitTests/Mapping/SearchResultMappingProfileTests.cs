namespace MusicAPI.Managers.Tests.Mapping
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SearchResultMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(SearchResultMappingProfile));
                configuration.AddProfile(typeof(ArtistsMappingProfile));
                configuration.AddProfile(typeof(ArtistMappingProfile));
                configuration.AddProfile(typeof(ExternalUrlMappingProfile));
                configuration.AddProfile(typeof(FollowersMappingProfile));
                configuration.AddProfile(typeof(ImageMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void SearchResultMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        // This test will most likely grow as new features are added into Search. TODO: consider breaking into separate tests as it grows.
        [Test]
        public void SearchResult_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            var searchResultDataTransferObject = new Accessors.DataTransferObjects.SearchResult
            {
                Artists = new Accessors.DataTransferObjects.Artists
                {
                    Total = 5
                }
            };

            // Act
            var searchResultViewModel = Mapper.Map<ViewModels.SearchResult>(searchResultDataTransferObject);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(searchResultViewModel.Artists.Total, Is.EqualTo(5));
            });
        }
    }
}
