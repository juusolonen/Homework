using System.Text.Json;
using Microsoft.Extensions.Options;
using Server.Configuration;
using Server.HttpClients.Abstractions;
using Server.Models;

namespace Server.HttpClients;

public class DummyJsonApiClient : IDummyJsonApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<DummyJsonApiClient> _logger;

    public DummyJsonApiClient(HttpClient httpClient, IOptions<ServerConfiguration.DummyApi> config, ILogger<DummyJsonApiClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _httpClient.BaseAddress = new Uri(config.Value.BaseUrl);
    }

    public async Task<ProductsResponse> GetProducts()
    {
        ProductsResponse? result;
        
        try
        {
            var rawResult = await _httpClient.GetStringAsync(Constants.DummyApiPaths.Products);
            result = JsonSerializer.Deserialize<ProductsResponse>(rawResult);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting products: {Message}", ex.Message);
            throw;
        }

        return result ?? new ProductsResponse
        {
            Products = [],
        };
    }
}