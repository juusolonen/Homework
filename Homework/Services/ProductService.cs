using Homework.HttpClients.Abstractions;
using Homework.Models;
using Homework.Services.Abstractions;

namespace Homework.Services;

public class ProductService(ILogger<ProductService> logger, IDummyApiClient httpClient) : IProductService
{
    public async Task<ProductsResponse> GetProducts()
    {
        logger.LogInformation("Productservice.GetProducts called");
        return await httpClient.GetProducts();
    }
}