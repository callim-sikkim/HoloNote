using MediatR;

namespace HoloNote.Core.CQRS.AskQuestion;

public class AskQuestionQueryHandler : IRequestHandler<AskQuestionQuery, AskQuestionViewModel>
{
    Task<AskQuestionViewModel> IRequestHandler<AskQuestionQuery, AskQuestionViewModel>.Handle(AskQuestionQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new AskQuestionViewModel { Answer = request.Question });
    }
}
