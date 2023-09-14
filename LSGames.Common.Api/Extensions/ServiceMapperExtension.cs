using LSGames.Common.Api.Services;
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

                // Repositories
                serviceCollection.AddScoped<INewsRepository, NewsRepository>();
                serviceCollection.AddScoped<INewsTypeRepository, NewsTypeRepository>();
                serviceCollection.AddScoped<IProductRepository, ProductRepository>();
                serviceCollection.AddScoped<IProductTypeRepository, ProductTypeRepository>();
                serviceCollection.AddScoped<IProductPlatformRepository, ProductPlatformRepository>();
                serviceCollection.AddScoped<IProductPlatformMapperRepository, ProductPlatformMapperRepository>();
            }

            return serviceCollection;
        }
    }
}
