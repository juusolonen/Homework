using Homework.Models;

namespace Homework.HttpClients.Abstractions;

public interface IDummyApiClient
{ 
    Task<ProductsResponse> GetProducts();
}