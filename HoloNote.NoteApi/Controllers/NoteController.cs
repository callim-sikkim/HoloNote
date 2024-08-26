using AutoMapper;
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
    public IActionResult CreateNote()
    {
        return Ok();
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
