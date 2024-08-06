using HoloNote.Core.Config;

namespace HoloNote.Core.Services;

public interface IAIService
{
    string TestFunction(string question);
}

public class AiService : IAIService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly AiConnectionConfig _aiConnection;

    public AiService(IHttpClientFactory httpClientFactory, AiConnectionConfig aiConnection)
    {
        _httpClientFactory = httpClientFactory;
        _aiConnection = aiConnection;
    }

    public string TestFunction(string question)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(_aiConnection.Url);
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _aiConnection.ApiKey);
        return httpClient.DefaultRequestHeaders.ToString();
    }
}
