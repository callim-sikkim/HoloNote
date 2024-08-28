using AutoMapper;

using HoloNote.ApiContract.Request;
using HoloNote.ApiContract.Response;
using HoloNote.Core.CQRS.AskQuestion;
using HoloNote.Core.CQRS.Note.Create;

namespace HoloNote.Core.AutoMapper.Profiles;

public class ContractToCqrsProfile : Profile
{
    public ContractToCqrsProfile()
    {
        #region Requests
        CreateMap<AiAskQuestionRequest, AskQuestionQuery>();
        CreateMap<CreateNoteRequest, CreateNoteCommand>();
        #endregion

        #region Response
        CreateMap<AskQuestionViewModel, AiAskQuestionResponse>();
        CreateMap<CreateNoteViewModel, CreateNoteResponse>();
        #endregion
    }
}
