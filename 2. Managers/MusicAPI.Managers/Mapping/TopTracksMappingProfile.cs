using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class TopTracksMappingProfile : Profile
    {
        public TopTracksMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.TopTracks, ViewModels.TopTracks>();
        }
    }
}
