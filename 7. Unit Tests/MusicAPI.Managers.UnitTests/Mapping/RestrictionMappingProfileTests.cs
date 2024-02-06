namespace MusicAPI.Managers.Tests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RestrictionMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(RestrictionMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void RestrictionMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void Restriction_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedReason = "Restriction Reason";

            var restrictionDataTransferObject = new Accessors.DataTransferObjects.Restriction
            {
                Reason = expectedReason
            };

            // Act
            var restrictionViewModel = Mapper.Map<ViewModels.Restriction>(restrictionDataTransferObject);

            // Assert
            Assert.That(restrictionViewModel.Reason, Is.EqualTo(expectedReason));
        }
    }
}
