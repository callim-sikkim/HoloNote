namespace HoloNote.Core.Services.Contract;

public class AiResponse : HttpResponseMessage
{
    public string Id { get; set; }
    public string Object { get; set; }
    public int Created { get; set; }
    public string Model { get; set; }
    public string System_fingerprint { get; set; }
    public List<Choice> Choices { get; set; }
    public UsageModel Usage { get; set; }

    public class Choice
    {
        public int Index { get; set; }
        public MessegeBase Message { get; set; }
        public object Logprobs { get; set; }
        public string Finish_reason { get; set; }
    }


    public class UsageModel
    {
        public int Prompt_tokens { get; set; }
        public int Completion_tokens { get; set; }
        public int Total_tokens { get; set; }
    }
}
