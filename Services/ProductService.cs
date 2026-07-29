using System.Net.Http.Json;

namespace BlazorApp;


public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Product>> Get()
    {
        var response = await _httpClient.GetAsync("api/v1/products");
        response.EnsureSuccessStatusCode();
        var products = await response.Content.ReadFromJsonAsync<List<Product>>();
        return products ?? new List<Product>();
    }

    public async Task Add(Product product)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/v1/products", product);
        response.EnsureSuccessStatusCode();
    }

    public async Task Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"/api/v1/products/{id}");
        response.EnsureSuccessStatusCode();
    }
}

public interface IProductService
{
    Task<List<Product>> Get();
    Task Add(Product product);
    Task Delete(int id);
}