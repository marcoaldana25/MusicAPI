using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class ArtistsMappingProfile : Profile
    {
        public ArtistsMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.Artists, ViewModels.Artists>();
        }
    }
}
