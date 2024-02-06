using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class RestrictionMappingProfile : Profile
    {
        public RestrictionMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.Restriction, ViewModels.Restriction>();
        }
    }
}
