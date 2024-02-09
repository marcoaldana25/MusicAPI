using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class RelatedArtistsMappingProfile : Profile
    {
        public RelatedArtistsMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.RelatedArtists, ViewModels.RelatedArtists>();
        }
    }
}
