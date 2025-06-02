using Server.Models;

namespace Server.HttpClients.Abstractions;

public interface IDummyJsonApiClient
{ 
    Task<ProductsResponse> GetProducts();
}