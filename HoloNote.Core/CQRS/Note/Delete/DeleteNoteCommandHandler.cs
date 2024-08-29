using HoloNote.DbConnection;

using MediatR;

namespace HoloNote.Core.CQRS.Note.Delete;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
{
    private readonly HoloNoteDbContext _dbContext;

    public DeleteNoteCommandHandler(HoloNoteDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = _dbContext.Find<Dto.Note>(request.Id);
        _dbContext.Remove(entity);
        _dbContext.SaveChanges();
        return Task.CompletedTask;
    }
}
