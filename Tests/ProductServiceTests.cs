using Microsoft.Extensions.Logging;
using Moq;
using Server.HttpClients.Abstractions;
using Server.Services;
using Tests.Helpers;

namespace Tests;

public class ProductServiceTests
{

    private readonly Mock<IDummyJsonApiClient> mockApiClient;
    private readonly ProductService productService;
    
    public ProductServiceTests()
    {
        var loggerMock = new Mock<ILogger<ProductService>>();
        mockApiClient = ApiClientTestHelper.GetApiClient();
        productService = new ProductService(loggerMock.Object, mockApiClient.Object);
    }

    [Fact]
    public async void ShouldReturnProductsResponse()
    {
        var result = await productService.GetProducts();
        
        Assert.NotNull(result);
        Assert.Single(result.Products);
        Assert.Equal(TestData.ProductsResponse.Products[0].Id, result.Products[0].Id);
        Assert.Equal(TestData.ProductsResponse.Products[0].Title, result.Products[0].Title);
        Assert.Equal(TestData.ProductsResponse.Products[0].Description, result.Products[0].Description);
        Assert.Equal(TestData.ProductsResponse.Products[0].Price, result.Products[0].Price);
        Assert.Equal(TestData.ProductsResponse.Products[0].ImageUrl, result.Products[0].ImageUrl);

        mockApiClient.Verify(x => x.GetProducts(), Times.Once);
    }
}