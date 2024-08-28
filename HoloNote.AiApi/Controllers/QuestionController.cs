using AutoMapper;

using HoloNote.ApiContract.Request;
using HoloNote.ApiContract.Response;
using HoloNote.Core.CQRS.AskQuestion;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace HoloNote.AiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IMapper _mapper;

        public QuestionController(IMediator mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<IActionResult> GetAnswer([FromBody] AiAskQuestionRequest question)
        {
            var query = _mapper.Map<AskQuestionQuery>(question);
            var response = await _mediatr.Send(query);
            return Ok(_mapper.Map<AiAskQuestionResponse>(response));
        }
    }
}
