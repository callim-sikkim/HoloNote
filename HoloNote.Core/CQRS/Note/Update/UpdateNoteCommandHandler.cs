using HoloNote.DbConnection;

using MediatR;

namespace HoloNote.Core.CQRS.Note.Update
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, UpdateNoteViewModel>
    {
        private readonly HoloNoteDbContext _dbContext;

        public UpdateNoteCommandHandler(HoloNoteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<UpdateNoteViewModel> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Update(request.Note);
            _dbContext.SaveChanges();
            return Task.FromResult(
                new UpdateNoteViewModel
                {
                    Note = request.Note
                }
                );
        }
    }
}
