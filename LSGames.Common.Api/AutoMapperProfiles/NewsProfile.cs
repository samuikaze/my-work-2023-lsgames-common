using AutoMapper;
using LSGames.Common.Api.Models.ServiceModels.News;
using LSGames.Common.Api.Models.ViewModels.News;
using LSGames.Common.Repository.Models;

namespace LSGames.Common.Api.AutoMapperProfiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<GetNewsResponseServiceModel, GetNewsResponseViewModel>();
            CreateMap<NewsType, NewsTypeServiceModel>().ReverseMap();
            CreateMap<NewsTypeServiceModel, NewsTypeViewModel>().ReverseMap();
            CreateMap<NewsViewModel, NewsServiceModel>().ReverseMap();
            CreateMap<NewsServiceModel, Repository.Models.News>().ReverseMap();
        }
    }
}
