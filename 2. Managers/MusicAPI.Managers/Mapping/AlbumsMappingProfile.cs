using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class AlbumsMappingProfile : Profile
    {
        public AlbumsMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.Albums, ViewModels.Albums>();
        }
    }
}
