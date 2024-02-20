using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class OwnerMappingProfile : Profile
    {
        public OwnerMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.Owner, ViewModels.Owner>();
        }
    }
}
