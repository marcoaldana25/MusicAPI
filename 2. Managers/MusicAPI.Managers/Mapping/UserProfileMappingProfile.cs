using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class UserProfileMappingProfile : Profile
    {
        public UserProfileMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.UserProfile, ViewModels.UserProfile>();
        }
    }
}
