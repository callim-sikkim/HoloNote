using AutoMapper;
using HoloNote.ApiContract.Request;
using HoloNote.ApiContract.Response;
using HoloNote.Core.CQRS.AskQuestion;

namespace HoloNote.Core.AutoMapper.Profiles;

public class ContractToCqrsProfile : Profile
{
    public ContractToCqrsProfile()
    {
        #region Requests
        CreateMap<AiAskQuestionRequest, AskQuestionQuery>();
        #endregion

        #region Response
        CreateMap<AskQuestionViewModel, AiAskQuestionResponse>();
        #endregion
    }
}
