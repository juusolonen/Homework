using Polly;
using Polly.Extensions.Http;

namespace Server.Extensions;

public static class HttpClientBuilderExtensions
{
    public static IHttpClientBuilder AddPolicyHandlers(this IHttpClientBuilder builder)
    {
        return builder.AddPolicyHandler(GetRetryPolicy())
            .AddPolicyHandler(GetCircuitBreakerPolicy());
    }
    
    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(Constants.HttpPolicies.RetryCount,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }
    
    public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(Constants.HttpPolicies.CircuitBreakerLimit, TimeSpan.FromSeconds(30));
    }
}