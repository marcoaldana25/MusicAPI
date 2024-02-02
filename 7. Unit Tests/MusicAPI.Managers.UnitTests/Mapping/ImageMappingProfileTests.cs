namespace MusicAPI.Managers.UnitTests.Mapping
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ImageMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(ImageMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void ImageMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void Image_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedUrl = "url";
            const int expectedHeight = 100;
            const int expectedWidth = 200;

            var imageDTO = new Accessors.DataTransferObjects.Image
            {
                Url = expectedUrl,
                Height = expectedHeight,
                Width = expectedWidth
            };

            // Act
            var imageViewModel = Mapper.Map<ViewModels.Image>(imageDTO);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(imageViewModel.Url, Is.EqualTo(expectedUrl));
                Assert.That(imageViewModel.Height, Is.EqualTo(expectedHeight));
                Assert.That(imageViewModel.Width, Is.EqualTo(expectedWidth));
            });
        }
    }
}
