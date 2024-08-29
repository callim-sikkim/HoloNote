using AutoMapper;

using HoloNote.DbConnection;

using MediatR;

namespace HoloNote.Core.CQRS.Note.Create;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, CreateNoteViewModel>
{
    private readonly HoloNoteDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateNoteCommandHandler(HoloNoteDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public Task<CreateNoteViewModel> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        _dbContext.Add(request.Note);
        _dbContext.SaveChanges();

        return Task.FromResult(
            new CreateNoteViewModel
            {
                Note = request.Note,
            }
            );
    }
}
