namespace MusicAPI.Managers.Tests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class OwnerMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(OwnerMappingProfile));
                configuration.AddProfile(typeof(ExternalUrlMappingProfile));
                configuration.AddProfile(typeof(FollowersMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void OwnerMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void Owner_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedHref = "href";
            const string expectedId = "id";
            const string expectedType = "type";
            const string expectedUri = "uri";
            const string expectedDisplayName = "displayName";

            var ownerDataTransferObject = new Accessors.DataTransferObjects.Owner
            {
                ExternalUrls = new Accessors.DataTransferObjects.ExternalUrl(),
                Followers = new Accessors.DataTransferObjects.Followers(),
                Href = expectedHref,
                Id = expectedId,
                Type = expectedType,
                Uri = expectedUri,
                DisplayName = expectedDisplayName
            };

            // Act
            var ownerViewModel = Mapper.Map<ViewModels.Owner>(ownerDataTransferObject);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(ownerViewModel.ExternalUrls, Is.Not.Null);
                Assert.That(ownerViewModel.Followers, Is.Not.Null);
                Assert.That(ownerViewModel.Href, Is.EqualTo(expectedHref));
                Assert.That(ownerViewModel.Id, Is.EqualTo(expectedId));
                Assert.That(ownerViewModel.Type, Is.EqualTo(expectedType));
                Assert.That(ownerViewModel.Uri, Is.EqualTo(expectedUri));
                Assert.That(ownerViewModel.DisplayName, Is.EqualTo(expectedDisplayName));
            });
        }
    }
}
