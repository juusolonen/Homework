using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Server.HttpClients.Abstractions;
using Server.Services;
using Tests.Helpers;

namespace Tests;

public class ProductServiceTests
{

    private readonly Mock<IDummyJsonApiClient> _mockApiClient;
    private readonly ProductService _productService;
    
    public ProductServiceTests()
    {
        var nullLogger = NullLogger<ProductService>.Instance;
        _mockApiClient = ApiClientTestHelper.GetApiClient();
        _productService = new ProductService(nullLogger, _mockApiClient.Object);
    }

    [Fact]
    public async void ShouldReturnProductsResponse()
    {
        var result = await _productService.GetProducts();
        
        Assert.NotNull(result);
        Assert.Single(result.Products);
        Assert.Equal(TestData.ProductsResponse.Products[0].Id, result.Products[0].Id);
        Assert.Equal(TestData.ProductsResponse.Products[0].Title, result.Products[0].Title);
        Assert.Equal(TestData.ProductsResponse.Products[0].Description, result.Products[0].Description);
        Assert.Equal(TestData.ProductsResponse.Products[0].Price, result.Products[0].Price);
        Assert.Equal(TestData.ProductsResponse.Products[0].ImageUrl, result.Products[0].ImageUrl);

        _mockApiClient.Verify(x => x.GetProducts(), Times.Once);
    }
}