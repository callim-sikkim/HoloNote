namespace HoloNote.Core.Services.Contract;

public class AiRequest
{
    public required string Model { get; set; }
    public required IList<MessegeBase> Messages { get; set; }
}
