using System.Text.Json;
using Microsoft.Extensions.Options;
using Server.Configuration;
using Server.HttpClients.Abstractions;
using Server.Models;

namespace Server.HttpClients;

public class DummyApiClient : IDummyApiClient
{
    private readonly HttpClient _httpClient;

    public DummyApiClient(HttpClient httpClient, IOptions<HomeworkConfiguration.DummyApi> config)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(config.Value.BaseUrl);
    }

    public async Task<ProductsResponse> GetProducts()
    {
        var rawResult = await _httpClient.GetStringAsync(Constants.DummyApiPaths.Products);
        var result = JsonSerializer.Deserialize<ProductsResponse>(rawResult);
        return result ?? new ProductsResponse
        {
            Products = [],
        };
    }
}