using System.Net.Http.Json;

namespace blazorapp;


public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Product>> Get()
    {
        var response = await _httpClient.GetAsync("/v1/products");
        response.EnsureSuccessStatusCode();
        var products = await response.Content.ReadFromJsonAsync<List<Product>>();
        return products ?? new List<Product>();
    }

    public async Task Add(Product product)
    {
        var response = await _httpClient.PostAsJsonAsync("/v1/products", product);
        response.EnsureSuccessStatusCode();
    }

    public async Task Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"/v1/products/{id}");
        response.EnsureSuccessStatusCode();
    }
}