using HoloNote.Dto;

namespace HoloNote.ApiContract.Request;

public class CreateNoteRequest
{
    public required Note Note { get; set; }
}
