using Microsoft.Extensions.Logging;

namespace Infrastructure;

public class LoggingHandler : DelegatingHandler
{
    private readonly ILogger<LoggingHandler> _logger;

    public LoggingHandler(ILogger<LoggingHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string content = await request.Content?.ReadAsStringAsync(cancellationToken) ?? string.Empty;

        _logger.LogInformation("{Method} request to {RequestUri} with content: {content}", request.Method, request.RequestUri, content);

        var response = await base.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("failed");
        }

        return response;
    }
}
