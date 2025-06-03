using Server.Models;

namespace Tests;

public static class TestData
{
    public static readonly ProductsResponse ProductsResponse = new()
    {
        Products =
        [
            new Product
            {
                Id = 0,
                Title = "test",
                Price = 1,
                Description = "test product",
                ImageUrl = ""
            }
        ],
    };
}