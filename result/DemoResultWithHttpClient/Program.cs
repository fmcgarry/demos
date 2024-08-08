using DemoResultWithHttpClient.PokemenApi;

var pokemonApiClient = new PokemonApiClient();

var pikachuHeight = await pokemonApiClient.GetPikachuHeight();
if (pikachuHeight is not null)
{
    Console.WriteLine($"Pikachu is {pikachuHeight} decimetres tall.");
}

var result = await pokemonApiClient.GetPikachuHeightUsingResult();
if (result.IsSuccessful)
{
    Console.WriteLine($"Pikachu is {result.Data} decimetres tall.");
}
