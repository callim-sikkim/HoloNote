using HoloNote.Core.Config;

namespace HoloNote.Core.Services;

public interface IAIService
{
    HttpClient GetHttp();
}

public class AiService : IAIService, IDisposable
{
    private readonly IHttpClientFactory _httpClientFactory;
    private HttpClient _httpClient;
    private readonly AiConnectionConfig _aiConnection;

    public AiService(IHttpClientFactory httpClientFactory, AiConnectionConfig aiConnection)
    {
        _httpClientFactory = httpClientFactory;
        _aiConnection = aiConnection;
    }

    private void CreateNewHttpClient()
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(_aiConnection.Url);
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _aiConnection.ApiKey);
        _httpClient = httpClient;
    }

    public HttpClient GetHttp()
    {
        if (_httpClient is null)
            CreateNewHttpClient();
        return _httpClient;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
