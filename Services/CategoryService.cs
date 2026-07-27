using System.Net.Http.Json;

namespace blazorapp;


public class CategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Category>> Get()
    {
        var response = await _httpClient.GetAsync("v1/categories");
        response.EnsureSuccessStatusCode();
        var categories = await response.Content.ReadFromJsonAsync<List<Category>>();
        return categories ?? new List<Category>();
    }
}