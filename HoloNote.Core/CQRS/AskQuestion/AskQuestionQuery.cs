using MediatR;

namespace HoloNote.Core.CQRS.AskQuestion;

public class AskQuestionQuery : IRequest<AskQuestionViewModel>
{
    public string Question { get; set; } = string.Empty;
}
