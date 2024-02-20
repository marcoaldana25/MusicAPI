using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class PlaylistMappingProfile : Profile
    {
        public PlaylistMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.Playlist, ViewModels.Playlist>();
        }
    }
}
