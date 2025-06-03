using Moq;
using Server.HttpClients.Abstractions;

namespace Tests.Helpers;

public static class ApiClientTestHelper
{
    public static Mock<IDummyJsonApiClient> GetApiClient()
    {
        var apiClientMock = new Mock<IDummyJsonApiClient>();
        
        apiClientMock
            .Setup(x => x.GetProducts())
            .ReturnsAsync(TestData.ProductsResponse);
        
        return apiClientMock;
    }
}