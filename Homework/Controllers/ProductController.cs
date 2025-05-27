using Homework.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Homework.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(ILogger<ProductController> logger, IProductService productService) : ControllerBase
{
    [HttpGet("Products")]
    [OutputCache(PolicyName = Constants.Cache.FiveSeconds)]
    public string GetProducts()
    {
        logger.LogInformation("GetProducts called");
        return productService.GetProducts();
    }
}