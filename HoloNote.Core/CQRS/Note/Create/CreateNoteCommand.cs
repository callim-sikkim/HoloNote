using MediatR;

namespace HoloNote.Core.CQRS.Note.Create;

public class CreateNoteCommand : IRequest<CreateNoteViewModel>
{
    public Dto.Note Note { get; set; }
}
