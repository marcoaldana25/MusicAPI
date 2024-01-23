using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class FollowersMappingProfile : Profile
    {
        public FollowersMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.Followers, ViewModels.Followers>();
        }
    }
}
