using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class TracksMappingProfile : Profile
    {
        public TracksMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.Tracks, ViewModels.Tracks>();
        }
    }
}
