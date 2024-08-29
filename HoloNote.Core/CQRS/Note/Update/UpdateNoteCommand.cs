using MediatR;

namespace HoloNote.Core.CQRS.Note.Update
{
    public class UpdateNoteCommand : IRequest<UpdateNoteViewModel>
    {
        public Dto.Note Note { get; set; }
    }
}
