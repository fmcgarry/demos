using Core.Interfaces;
using Infrastructure.CatFactsApi.Requests;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Infrastructure.CatFactsApi;

public class CatFactsApiClient : ICatFactsApiClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly CatFactsApiClientOptions _options;

    public CatFactsApiClient(IHttpClientFactory httpClientFactory, IOptions<CatFactsApiClientOptions> options)
    {
        _httpClientFactory = httpClientFactory;
        _options = options.Value;
    }

    public async Task<string> GetRandomCatFactAsync()
    {
        var request = new RandomCatFactRequest();
        var response = await SendRequest(request);

        return response;
    }

    private async Task<string> SendRequest(ICatFactRequest request)
    {
        var client = _httpClientFactory.CreateClient(nameof(CatFactsApiClient));
        client.BaseAddress = new Uri(_options.BaseAddress);

        var httpRequestMessage = new HttpRequestMessage(request.Method, request.GetRequestUrl())
        {
            Content = JsonContent.Create(request.GetPayload()),
        };

        var response = await client.SendAsync(httpRequestMessage);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}
