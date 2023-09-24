using LSGames.Common.Api.Services;
using LSGames.Common.Repository.Repositories.Carousel;
using LSGames.Common.Repository.Repositories.Faq;
using LSGames.Common.Repository.Repositories.News;
using LSGames.Common.Repository.Repositories.Product;

namespace LSGames.Common.Api.Extensions
{
    public class ServiceMapperExtension
    {
        public static IServiceCollection? GetServiceProvider(IServiceCollection? serviceCollection)
        {
            if (serviceCollection != null)
            {
                // Services
                serviceCollection.AddScoped<INewsService, NewsService>();
                serviceCollection.AddScoped<IProductService, ProductService>();
                serviceCollection.AddScoped<IFaqService, FaqService>();
                serviceCollection.AddScoped<ICarouselService, CarouselService>();

                // Repositories
                serviceCollection.AddScoped<INewsRepository, NewsRepository>();
                serviceCollection.AddScoped<INewsTypeRepository, NewsTypeRepository>();
                serviceCollection.AddScoped<IProductRepository, ProductRepository>();
                serviceCollection.AddScoped<IProductTypeRepository, ProductTypeRepository>();
                serviceCollection.AddScoped<IProductPlatformRepository, ProductPlatformRepository>();
                serviceCollection.AddScoped<IProductPlatformMapperRepository, ProductPlatformMapperRepository>();
                serviceCollection.AddScoped<IFaqRepository, FaqRepository>();
                serviceCollection.AddScoped<ICarouselRepository, CarouselRepository>();
            }

            return serviceCollection;
        }
    }
}
