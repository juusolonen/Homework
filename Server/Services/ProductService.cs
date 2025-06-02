using Server.HttpClients.Abstractions;
using Server.Models;
using Server.Services.Abstractions;

namespace Server.Services;

public class ProductService(ILogger<ProductService> logger, IDummyJsonApiClient httpClient) : IProductService
{
    public async Task<ProductsResponse> GetProducts()
    {
        logger.LogInformation("Productservice.GetProducts called");
        return await httpClient.GetProducts();
    }
}