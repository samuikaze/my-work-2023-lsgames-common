using AutoMapper;
using LSGames.Common.Api.Models.ServiceModels.Faq;
using LSGames.Common.Api.Models.ViewModels.Faq;
using LSGames.Common.Repository.Models;

namespace LSGames.Common.Api.AutoMapperProfiles
{
    public class FaqProfile : Profile
    {
        public FaqProfile()
        {
            CreateMap<FaqViewModel, FaqServiceModel>().ReverseMap();
            CreateMap<FaqServiceModel, Faq>().ReverseMap();
            CreateMap<GetFaqListResponseServiceModel, GetFaqListResponseViewModel>();
        }
    }
}
