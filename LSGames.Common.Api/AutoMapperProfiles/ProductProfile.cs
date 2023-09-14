using AutoMapper;
using LSGames.Common.Api.Models.ViewModels;
using LSGames.Common.Api.Models.ServiceModels;
using LSGames.Common.Api.Models.ServiceModels.Product;
using LSGames.Common.Api.Models.ViewModels.Product;
using LSGames.Common.Repository.Models;

namespace LSGames.Common.Api.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetPaginatorEntitiesRequestViewModel, GetPaginatorEntitiesRequestServiceModel>();
            CreateMap<ProductViewModel, ProductServiceModel>().ReverseMap();
            CreateMap<ProductServiceModel, Repository.Models.Product>().ReverseMap();
            CreateMap<GetProductsResponseServiceModel, GetProductsResponseViewModel>();
            CreateMap<CreateProductRequestViewModel, CreateProductRequestServiceModel>();
            CreateMap<CreateProductRequestServiceModel, Repository.Models.Product>();
            CreateMap<ProductTypeViewModel, ProductTypeServiceModel>().ReverseMap();
            CreateMap<ProductTypeServiceModel, Repository.Models.ProductType>().ReverseMap();
            CreateMap<GetProductTypesResponseServiceModel, GetProductTypesResponseViewModel>();
            CreateMap<ProductPlatformViewModel, ProductPlatformServiceModel>().ReverseMap();
            CreateMap<ProductPlatformServiceModel, ProductPlatform>().ReverseMap();
        }
    }
}
