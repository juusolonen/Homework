using System.Text.Json;
using Microsoft.Extensions.Options;
using Server.Configuration;
using Server.HttpClients.Abstractions;
using Server.Models;

namespace Server.HttpClients;

public class DummyApiClient : IDummyApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<DummyApiClient> _logger;

    public DummyApiClient(HttpClient httpClient, IOptions<HomeworkConfiguration.DummyApi> config, ILogger<DummyApiClient> logger)
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