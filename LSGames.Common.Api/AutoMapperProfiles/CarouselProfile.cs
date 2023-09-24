using AutoMapper;
using LSGames.Common.Api.Models.ServiceModels.Carousel;
using LSGames.Common.Api.Models.ViewModels.Carousel;
using LSGames.Common.Repository.Models;

namespace LSGames.Common.Api.AutoMapperProfiles
{
    public class CarouselProfile : Profile
    {
        public CarouselProfile()
        {
            CreateMap<CarouselViewModel, CarouselServiceModel>().ReverseMap();
            CreateMap<CarouselServiceModel, Carousel>().ReverseMap();
            CreateMap<GetCarouselListResponseServiceModel, GetCarouselListResponseViewModel>();
        }
    }
}
