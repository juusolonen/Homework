using System.Net;
using Moq;
using Moq.Protected;

namespace Tests.Helpers;

public static class HttpClientTestHelper
{
    public static (HttpClient, Func<int> getCallCount) GetMockPolicyClient()
    {
        int callCount = 0;
        
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(() =>
            {
                callCount++;
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            });
        
        var client = new HttpClient(mockHandler.Object)
        {
            BaseAddress = new Uri("https://fake.not.exists.api")
        };
        
        return (client, () => callCount);
    }
}