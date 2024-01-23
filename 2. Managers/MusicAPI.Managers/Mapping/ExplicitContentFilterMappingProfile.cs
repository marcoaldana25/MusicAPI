using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class ExplicitContentFilterMappingProfile : Profile
    {
        public ExplicitContentFilterMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.ExplicitContentFilter, ViewModels.ExplicitContentFilter>();
        }
    }
}
