namespace Infrastructure.CatFactsApi.Requests
{
    public interface ICatFactRequest
    {
        HttpMethod Method { get; }

        string GetRequestUrl();
        string? GetPayload() => null;
        public bool IsValid() => true;
    }
}