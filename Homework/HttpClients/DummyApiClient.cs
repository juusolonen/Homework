using System.Text.Json;
using Homework.Configuration;
using Homework.HttpClients.Abstractions;
using Homework.Models;
using Microsoft.Extensions.Options;

namespace Homework.HttpClients;

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