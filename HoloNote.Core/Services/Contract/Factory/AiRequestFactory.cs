namespace HoloNote.Core.Services.Contract.Factory;

public static class AiRequestFactory
{
    private const string MODEL = "gpt-4o-mini";
    private const string ROLE1 = "assistant";
    private const string ROLE2 = "user";
    private const string CONTENT = "University teacher";
    public static AiRequest Build(string question) => new AiRequest
    {
        Model = MODEL,
        Messages = new List<MessegeBase>
        {
            new MessegeBase {
                Role = ROLE1,
                Content = CONTENT
            },
            new MessegeBase {
                Role = ROLE2,
                Content = question
            }
        }
    };

}
