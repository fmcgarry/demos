namespace Core.Interfaces;

public interface ICatFactsApiClient
{
    Task<string> GetRandomCatFactAsync();
}
