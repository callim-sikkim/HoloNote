using AutoMapper;

using HoloNote.ApiContract.Request;
using HoloNote.ApiContract.Response;
using HoloNote.Core.CQRS.Note.Create;
using HoloNote.Core.CQRS.Note.Delete;
using HoloNote.Core.CQRS.Note.Update;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace HoloNote.NoteApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public NoteController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetListNote()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetNote(int id)
    {
        return Ok(new { id });
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] CreateNoteRequest request)
    {
        var command = _mapper.Map<CreateNoteCommand>(request);
        var response = await _mediator.Send(command, HttpContext.RequestAborted);
        return Ok(_mapper.Map<CreateNoteResponse>(response));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateNote([FromBody] UpdateNoteRequest request)
    {
        var command = _mapper.Map<UpdateNoteCommand>(request);
        var response = await _mediator.Send(command, HttpContext.RequestAborted);
        return Ok(_mapper.Map<UpdateNoteResponse>(response));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNote([FromRoute] long id)
    {
        var request = new DeleteNoteRequest { Id = id };
        var command = _mapper.Map<DeleteNoteCommand>(request);
        await _mediator.Send(command, HttpContext.RequestAborted);
        return Ok();
    }
}
