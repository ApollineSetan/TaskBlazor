using BlazorApp.Shared.Models;
using System.Net.Http.Json;

namespace BlazorApp.Client.Services
{
    public class ItemService
    {
        private readonly HttpClient _http;

        public ItemService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            return await _http.GetFromJsonAsync<List<Item>>("api/items") ?? new();
        }

        public async Task<Item> GetItemAsync(int id)
        {
            var item = await _http.GetFromJsonAsync<Item>($"api/items/{id}");
            return item ?? new Item();
        }

        public async Task AddItemAsync(Item item)
        {
            var response = await _http.PostAsJsonAsync("api/items", item);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateItemAsync(Item item)
        {
            var response = await _http.PutAsJsonAsync($"api/items/{item.Id}", item);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteItemAsync(int itemId)
        {
            var response = await _http.DeleteAsync($"api/items/{itemId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
