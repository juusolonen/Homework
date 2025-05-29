using System.Text.Json.Serialization;

namespace Server.Models;

public record ProductsResponse
{
    [JsonPropertyName("products")]
    public required List<Product> Products { get; init; }
    
    [JsonPropertyName("total")]
    public int Total { get; init; }
}