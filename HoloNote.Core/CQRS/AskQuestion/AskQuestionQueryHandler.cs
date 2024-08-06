using HoloNote.Core.Services;
using MediatR;

namespace HoloNote.Core.CQRS.AskQuestion;

public class AskQuestionQueryHandler : IRequestHandler<AskQuestionQuery, AskQuestionViewModel>
{
    private readonly IAIService _aiService;

    public AskQuestionQueryHandler(IAIService aiService)
    {
        _aiService = aiService;
    }
    Task<AskQuestionViewModel> IRequestHandler<AskQuestionQuery, AskQuestionViewModel>.Handle(AskQuestionQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new AskQuestionViewModel { Answer = _aiService.TestFunction(request.Question) });
    }
}
