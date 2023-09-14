using LSGames.Common.Api.HttpClients;

namespace LSGames.Common.Api.Extensions
{
    public class HttpClientExtension
    {
        public static IServiceCollection ConfigureHttpClients(IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<SingleSignOnClient>();

            return serviceCollection;
        }
    }
}
