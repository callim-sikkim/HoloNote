using MediatR;

namespace HoloNote.Core.CQRS.Note.Delete
{
    public class DeleteNoteCommand : IRequest
    {
        public long Id { get; set; }
    }
}
