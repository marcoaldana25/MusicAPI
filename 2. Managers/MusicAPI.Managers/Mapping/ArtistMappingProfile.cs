using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class ArtistMappingProfile : Profile
    {
        public ArtistMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.Artist, ViewModels.Artist>();
        }
    }
}
