﻿using HoloNote.Core.Services;
using HoloNote.Core.Services.Contract;
using HoloNote.Core.Services.Contract.Factory;
using MediatR;
using System.Net.Http.Json;

namespace HoloNote.Core.CQRS.AskQuestion;

public class AskQuestionQueryHandler : IRequestHandler<AskQuestionQuery, AskQuestionViewModel>
{
    private readonly IAIService _aiService;

    public AskQuestionQueryHandler(IAIService aiService)
    {
        _aiService = aiService;
    }
    async Task<AskQuestionViewModel> IRequestHandler<AskQuestionQuery, AskQuestionViewModel>.Handle(AskQuestionQuery request, CancellationToken cancellationToken)
    {
        var httpClient = _aiService.GetHttp();
        var aiRequest = AiRequestFactory.Build(request.Question);


        var response = await httpClient.PostAsJsonAsync(string.Empty, aiRequest, cancellationToken);
        var result = await response.Content.ReadFromJsonAsync<AiResponse>(cancellationToken);

        return new AskQuestionViewModel { Answer = result.Choices.First().Message.Content.Normalize() };
    }
}
