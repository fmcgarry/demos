using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CatFactsApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCatFactsApiClient(this IServiceCollection services, IConfiguration namedConfigurationSection)
    {
        services.Configure<CatFactsApiClientOptions>(namedConfigurationSection);

        services.AddTransient<LoggingHandler>();

        services.AddHttpClient(nameof(CatFactsApiClient))
            .AddHttpMessageHandler<LoggingHandler>();

        services.AddScoped<ICatFactsApiClient, CatFactsApiClient>();

        return services;
    }
}
