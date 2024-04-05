using Core.Interfaces;

namespace Core;

public class AnimalFactService : IAnimalFactService
{
    private readonly ICatFactsApiClient _catFactsApiClient;

    public AnimalFactService(ICatFactsApiClient catFactsApiClient)
    {
        _catFactsApiClient = catFactsApiClient;
    }

    public async Task<string> GetRandomCatFactAsync()
    {
        string result = await _catFactsApiClient.GetRandomCatFactAsync();
        return result;
    }
}
