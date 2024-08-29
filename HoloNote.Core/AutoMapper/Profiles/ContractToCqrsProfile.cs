using AutoMapper;

using HoloNote.ApiContract.Request;
using HoloNote.ApiContract.Response;
using HoloNote.Core.CQRS.AskQuestion;
using HoloNote.Core.CQRS.Note.Create;
using HoloNote.Core.CQRS.Note.Delete;
using HoloNote.Core.CQRS.Note.Update;

namespace HoloNote.Core.AutoMapper.Profiles;

public class ContractToCqrsProfile : Profile
{
    public ContractToCqrsProfile()
    {
        #region Requests
        CreateMap<AiAskQuestionRequest, AskQuestionQuery>();
        CreateMap<CreateNoteRequest, CreateNoteCommand>();
        CreateMap<UpdateNoteRequest, UpdateNoteCommand>();
        CreateMap<DeleteNoteRequest, DeleteNoteCommand>();
        #endregion

        #region Response
        CreateMap<AskQuestionViewModel, AiAskQuestionResponse>();
        CreateMap<CreateNoteViewModel, CreateNoteResponse>();
        CreateMap<UpdateNoteViewModel, UpdateNoteResponse>();
        #endregion
    }
}
