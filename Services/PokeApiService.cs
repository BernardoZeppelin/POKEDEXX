// POKEDEXX/Services/PokeApiService.cs

using POKEDEXX.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace POKEDEXX.Services;

public class PokeApiService
{
    private readonly HttpClient _httpClient;

    public PokeApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new System.Uri("https://pokeapi.co/api/v2/");
    }

    
    public async Task<PokemonViewModel> GetPokemonAsync(string identifier)
    {
       
        if (string.IsNullOrWhiteSpace(identifier))
        {
            return null;
        }

       
        var response = await _httpClient.GetAsync($"pokemon/{identifier}");

        if (response.IsSuccessStatusCode)
        {   
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var pokemon = JsonSerializer.Deserialize<PokemonViewModel>(content, options);
            return pokemon;
        }

        return null; 
    }
}