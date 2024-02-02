using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class SearchResultMappingProfile : Profile
    {
        public SearchResultMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.SearchResult, ViewModels.SearchResult>();
        }
    }
}
