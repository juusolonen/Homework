using Homework.Models;

namespace Homework.Services.Abstractions;

public interface IProductService
{
    Task<ProductsResponse> GetProducts();
}