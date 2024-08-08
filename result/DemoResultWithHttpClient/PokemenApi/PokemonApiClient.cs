using System.Net.Http.Json;

namespace DemoResultWithHttpClient.PokemenApi;

public class PokemonApiClient
{
    private static readonly HttpClient _httpClient = new();

    public async Task<int?> GetPikachuHeight()
    {
        var result = await _httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/pikachu");
        if (result.IsSuccessStatusCode)
        {
            var pokemon = await result.Content.ReadFromJsonAsync<Pokemon>();
            if (pokemon is not null)
            {
                return pokemon.height;
            }
        }

        // How do we differentiate between an unsuccessful call and an unsuccessful deserialization?
        // What if height is nullable?
        return null;
    }

    public async Task<Result<int>> GetPikachuHeightUsingResult()
    {
        // Using Result<T> grants the ability to specify exactly what happened.
        // If height is nullable, Result is able to differentiate between a success and fail.

        var response = await _httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/pikachu");
        if (!response.IsSuccessStatusCode)
        {
            return Result<int>.Fail($"Response was unsuccessful: {response}");
        }

        var pokemon = await response.Content.ReadFromJsonAsync<Pokemon>();
        if (pokemon is null)
        {
            return Result<int>.Fail("Failed to deserialize response content.");
        }

        return Result<int>.Success(pokemon.height);
    }
}
