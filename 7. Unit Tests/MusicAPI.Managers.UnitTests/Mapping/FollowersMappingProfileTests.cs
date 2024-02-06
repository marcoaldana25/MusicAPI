namespace MusicAPI.Managers.UnitTests.Mapping
{
#pragma warning disable CS8602
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FollowersMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(FollowersMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void FollowersMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void Followers_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedHref = "href";
            const int expectedTotal = 100;

            var followersDTO = new Accessors.DataTransferObjects.Followers
            {
                Href = expectedHref,
                Total = expectedTotal
            };

            // Act
            var followersViewModel = Mapper.Map<ViewModels.Followers>(followersDTO);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(followersViewModel.Href, Is.EqualTo(expectedHref));
                Assert.That(followersViewModel.Total, Is.EqualTo(expectedTotal));
            });
        }
    }
}
