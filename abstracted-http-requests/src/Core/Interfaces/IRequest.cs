namespace Core.Interfaces;

public interface IRequest
{
    public HttpMethod Method { get; }
    public string Uri { get; }
    public string Body { get; set; }
}
