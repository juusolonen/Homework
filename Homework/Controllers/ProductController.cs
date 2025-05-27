using Microsoft.AspNetCore.Mvc;

namespace Homework.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(ILogger<ProductController> logger) : ControllerBase
{
    [HttpGet("Products")]
    public IActionResult GetProducts()
    {
        logger.LogInformation("GetProducts called");
        return Ok();
    }
}