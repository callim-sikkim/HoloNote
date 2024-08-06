namespace HoloNote.Core.Config;

public class AiConnectionConfig
{
    public string ApiKey { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public double LifeTimeSpan { get; set; }
}
