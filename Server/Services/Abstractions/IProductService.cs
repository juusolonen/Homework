using Server.Models;

namespace Server.Services.Abstractions;

public interface IProductService
{
    Task<ProductsResponse> GetProducts();
}