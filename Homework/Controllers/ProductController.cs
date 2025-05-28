using Homework.Models;
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
    [ProducesResponseType(typeof(ProductsResponse), StatusCodes.Status200OK)]
    public async Task<ProductsResponse> GetProducts()
    {
        logger.LogInformation("GetProducts called");
        return await productService.GetProducts();
    }
}