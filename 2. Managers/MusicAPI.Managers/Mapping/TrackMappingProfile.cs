using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class TrackMappingProfile : Profile
    {
        public TrackMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.Track, ViewModels.Track>();
        }
    }
}
