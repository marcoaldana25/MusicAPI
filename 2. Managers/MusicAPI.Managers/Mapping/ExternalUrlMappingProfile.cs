using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class ExternalUrlMappingProfile : Profile
    {
        public ExternalUrlMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.ExternalUrl, ViewModels.ExternalUrl>();
        }
    }
}
