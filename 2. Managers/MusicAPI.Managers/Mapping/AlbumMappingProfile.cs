using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class AlbumMappingProfile : Profile
    {
        public AlbumMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.Album, ViewModels.Album>();
        }
    }
}
