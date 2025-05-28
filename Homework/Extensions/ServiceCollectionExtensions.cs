using Homework.Services;
using Homework.Services.Abstractions;

namespace Homework.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }

    public static void ConfigureOutPutCache(this IServiceCollection services)
    {
        services.AddOutputCache(opt =>
        {
            opt.AddPolicy(Constants.Cache.FiveSeconds, policyBuilder =>
            {
                policyBuilder.Expire(TimeSpan.FromSeconds(5));
            });
        });
    }
}