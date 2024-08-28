using AutoMapper;

using HoloNote.ApiContract.Request;
using HoloNote.ApiContract.Response;
using HoloNote.Core.CQRS.Note.Create;

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
        var response = await _mediator.Send(command);
        return Ok(_mapper.Map<CreateNoteResponse>(response));
    }

    [HttpPut]
    public IActionResult UpdateNote(int id)
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteNote(int id)
    {
        return Ok();
    }
}
