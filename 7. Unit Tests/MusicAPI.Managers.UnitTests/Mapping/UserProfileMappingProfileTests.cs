using AutoMapper;
using MusicAPI.Managers.Mapping;
using System.Diagnostics.CodeAnalysis;

namespace MusicAPI.Managers.UnitTests.Mapping
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UserProfileMappingProfileTests
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(UserProfileMappingProfile));
                configuration.AddProfile(typeof(ImageMappingProfile));
                configuration.AddProfile(typeof(FollowersMappingProfile));
                configuration.AddProfile(typeof(ExternalUrlMappingProfile));
                configuration.AddProfile(typeof(ExplicitContentFilterMappingProfile));
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void UserProfileMappingProfile_AssertConfigurationIsValid()
        {
            // Act & Assert
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void UserProfile_DataTransferObject_To_ViewModel_ShouldMap()
        {
            // Arrange
            const string expectedCountry = "USA";
            const string expectedDisplayName = "Display name";
            const string expectedEmailAddress = "email@address.com";
            const string expectedExternalUrl = "Spotify";
            const string expectedFollowersHref = "Followers href";
            const int expectedFollowersTotal = 100;
            const string expectedUserProfileHref = "User Profile Href";
            const string expectedId = "SpotifyId";
            const int expectedImageHeight = 100;
            const int expectedImageWidth = 200;
            const string expectedImageUrl = "Image Url";
            const string expectedProduct = "Product";
            const string expectedType = "Type";
            const string expectedUri = "Spotify Uri";

            var userProfileDTO = new Accessors.DataTransferObjects.UserProfile
            {
                Country = expectedCountry,
                DisplayName = expectedDisplayName,
                EmailAddress = expectedEmailAddress,
                ExplicitContentFilter = new Accessors.DataTransferObjects.ExplicitContentFilter
                {
                    FilterEnabled = true,
                    FilterLocked = true
                },
                ExternalUrls = new Accessors.DataTransferObjects.ExternalUrl
                {
                    Spotify = expectedExternalUrl
                },
                Followers = new Accessors.DataTransferObjects.Followers
                {
                    Href = expectedFollowersHref,
                    Total = expectedFollowersTotal
                },
                Href = expectedUserProfileHref,
                Id = expectedId,
                Images =
                [
                    new Accessors.DataTransferObjects.Image
                    {
                        Height = expectedImageHeight,
                        Width = expectedImageWidth,
                        Url = expectedImageUrl
                    }
                ],
                Product = expectedProduct,
                Type = expectedType,
                Uri = expectedUri
            };

            // Act
            var userProfileViewModel = Mapper.Map<ViewModels.UserProfile>(userProfileDTO);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(userProfileViewModel.Country, Is.EqualTo(expectedCountry));
                Assert.That(userProfileViewModel.DisplayName, Is.EqualTo(expectedDisplayName));
                Assert.That(userProfileViewModel.EmailAddress, Is.EqualTo(expectedEmailAddress));

                Assert.That(userProfileViewModel.ExplicitContentFilter.FilterEnabled, Is.True);
                Assert.That(userProfileViewModel.ExplicitContentFilter.FilterLocked, Is.True);

                Assert.That(userProfileViewModel.ExternalUrls.Spotify, Is.EqualTo(expectedExternalUrl));

                Assert.That(userProfileViewModel.Followers.Href, Is.EqualTo(expectedFollowersHref));
                Assert.That(userProfileViewModel.Followers.Total, Is.EqualTo(expectedFollowersTotal));

                Assert.That(userProfileViewModel.Href, Is.EqualTo(expectedUserProfileHref));
                Assert.That(userProfileViewModel.Id, Is.EqualTo(expectedId));

                Assert.That(userProfileViewModel.Images[0].Height, Is.EqualTo(expectedImageHeight));
                Assert.That(userProfileViewModel.Images[0].Width, Is.EqualTo(expectedImageWidth));
                Assert.That(userProfileViewModel.Images[0].Url, Is.EqualTo(expectedImageUrl));

                Assert.That(userProfileViewModel.Product, Is.EqualTo(expectedProduct));
                Assert.That(userProfileViewModel.Type, Is.EqualTo(expectedType));
                Assert.That(userProfileViewModel.Uri, Is.EqualTo(expectedUri));
            });
        }
    }
}
