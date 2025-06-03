using Polly.CircuitBreaker;
using Server;
using Tests.Helpers;
using HttpClientBuilderExtensions = Server.Extensions.HttpClientBuilderExtensions;

namespace Tests;

public class HttpPolicyTests
{

    private readonly HttpClient _mockClient;
    private readonly Func<int> _getCallCount;
    private readonly string _mockPath = Constants.DummyApiPaths.Products;
    
    public HttpPolicyTests()
    {
        (_mockClient, _getCallCount) = HttpClientTestHelper.GetMockPolicyClient();
    }
    
    [Fact]
    public async void RetryPolicyWorks()
    {
        var retryPolicy = HttpClientBuilderExtensions.GetRetryPolicy();

        await retryPolicy.ExecuteAsync(() => _mockClient.GetAsync(_mockPath));

        var expected = Constants.HttpPolicies.RetryCount + 1; 
        
        Assert.Equal(expected, _getCallCount());
    }
    
    [Fact]
    public async void CircuitBreakerPolicyWorks()
    {
        var breakerPolicy = HttpClientBuilderExtensions.GetCircuitBreakerPolicy();
        
        for (int i = 0; i < Constants.HttpPolicies.CircuitBreakerLimit; i++)
        {
            await breakerPolicy.ExecuteAsync(() => _mockClient.GetAsync(_mockPath));
        }
        
        await Assert.ThrowsAsync<BrokenCircuitException<HttpResponseMessage>>(async () =>
            await breakerPolicy.ExecuteAsync(() => _mockClient.GetAsync(_mockPath)));
    }
}