namespace MusicAPI.Managers.Tests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ExternalIdMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(ExternalIdMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void ExternalIdMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void ExternalId_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedInternationalArticleNumber = "IAN";
            const string expectedInternationalStandardRecordingCode = "ISRC";
            const string expectedUniversalProductCode = "UPC";

            var externalIdDataTransferObject = new Accessors.DataTransferObjects.ExternalId
            {
                InternationalArticleNumber = expectedInternationalArticleNumber,
                InternationalStandardRecordingCode = expectedInternationalStandardRecordingCode,
                UniversalProductCode = expectedUniversalProductCode
            };

            // Act
            var externalIdViewModel = Mapper.Map<ViewModels.ExternalId>(externalIdDataTransferObject);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(externalIdViewModel.InternationalArticleNumber, Is.EqualTo(expectedInternationalArticleNumber));
                Assert.That(externalIdViewModel.InternationalStandardRecordingCode, Is.EqualTo(expectedInternationalStandardRecordingCode));
                Assert.That(externalIdViewModel.UniversalProductCode, Is.EqualTo(expectedUniversalProductCode));
            });
        }
    }
}
