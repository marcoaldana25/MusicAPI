using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class ExternalIdMappingProfile : Profile
    {
        public ExternalIdMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.ExternalId, ViewModels.ExternalId>();
        }
    }
}
