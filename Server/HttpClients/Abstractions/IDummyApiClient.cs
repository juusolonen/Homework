using Server.Models;

namespace Server.HttpClients.Abstractions;

public interface IDummyApiClient
{ 
    Task<ProductsResponse> GetProducts();
}