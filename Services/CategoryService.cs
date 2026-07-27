using System.Net.Http.Json;

namespace BlazorApp;


public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Category>> Get()
    {
        var response = await _httpClient.GetAsync("api/v1/categories");
        response.EnsureSuccessStatusCode();
        var categories = await response.Content.ReadFromJsonAsync<List<Category>>();
        return categories ?? new List<Category>();
    }
}

public interface ICategoryService
{
    Task<List<Category>> Get();
}