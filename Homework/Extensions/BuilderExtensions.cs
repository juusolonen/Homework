using NLog.Web;

namespace Homework.Extensions;

public static class BuilderExtensions
{
    public static void ConfigureLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Host.UseNLog();
    }
}