using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddLocalFileRepository(this IServiceCollection services)
    {
        services.AddScoped<ILocalFileRepository, LocalFileService>();
        return services;
    }

    public static IServiceCollection AddWebpageService(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IWebpageService, WebpageService>();
        return services;
    }

    public static IServiceCollection AddMetadataService(this IServiceCollection services)
    {
        services.AddScoped<IMetadataService, MetadataService>();
        return services;
    }

    public static IServiceCollection AddFetchService(this IServiceCollection services)
    {
        services.AddScoped<FetchPageService>();
        return services;
    }

}