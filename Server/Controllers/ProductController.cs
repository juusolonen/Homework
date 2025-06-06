using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Server.Models;
using Server.Services.Abstractions;

namespace Server.Controllers;

[ApiController]
[Route("/")]
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