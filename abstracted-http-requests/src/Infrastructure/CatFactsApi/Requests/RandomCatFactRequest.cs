namespace Infrastructure.CatFactsApi.Requests;

public class RandomCatFactRequest : ICatFactRequest
{
    public HttpMethod Method => HttpMethod.Get;

    public string GetRequestUrl()
    {
        return "/facts/random?animal_type=cat&amount=1";
    }
}
