using AutoMapper;

namespace MusicAPI.Managers.Mapping
{
    public class ImageMappingProfile : Profile
    {
        public ImageMappingProfile()
        {
            CreateMap<Accessors.DataTransferObjects.Image, ViewModels.Image>();
        }
    }
}
