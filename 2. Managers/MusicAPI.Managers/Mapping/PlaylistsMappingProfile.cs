using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class PlaylistsMappingProfile : Profile
    {
        public PlaylistsMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.Playlists, ViewModels.Playlists>();
        }
    }
}
