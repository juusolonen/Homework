using Homework.Services;
using Homework.Services.Abstractions;

namespace Homework.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }
}