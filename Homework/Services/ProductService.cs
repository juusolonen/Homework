using Homework.Services.Abstractions;

namespace Homework.Services;

public class ProductService(ILogger<ProductService> logger) : IProductService
{
    public string GetProducts()
    {
        logger.LogInformation("Productservice.GetProducts called");
        return "This is a product service";
    }
}