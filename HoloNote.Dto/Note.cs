namespace HoloNote.Dto;

public class Note
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
}
