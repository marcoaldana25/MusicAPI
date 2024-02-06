namespace MusicAPI.Managers.UnitTests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ExplicitContentFilterMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(ExplicitContentFilterMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void ExplicitContentFilterMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void ExplicitContentFilter_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            var explicitContentFilterDTO = new Accessors.DataTransferObjects.ExplicitContentFilter
            {
                FilterLocked = true,
                FilterEnabled = true
            };

            // Act
            var explicitContentFilterViewModel = Mapper.Map<ViewModels.ExplicitContentFilter>(explicitContentFilterDTO);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(explicitContentFilterViewModel.FilterEnabled, Is.True);
                Assert.That(explicitContentFilterViewModel.FilterLocked, Is.True);
            });
        }
    }
}
