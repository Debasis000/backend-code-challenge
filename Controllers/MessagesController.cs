using CodeChallenge.Api.Logic;
using CodeChallenge.Api.Models;
using CodeChallenge.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Api.Controllers;

[ApiController]
[Route("api/v1/messages")]
public class MessagesController : ControllerBase
{
    private readonly IMessageLogic _messageLogic;

    public MessagesController(IMessageLogic messageLogic)
    {
        _messageLogic = messageLogic;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var message = await _messageLogic.GetByIdAsync(id);
        if (message == null) return NotFound();
        return Ok(message);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMessageRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var created = await _messageLogic.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMessageRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var updated = await _messageLogic.UpdateMessageAsync(id, request);
        if (updated == null) return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _messageLogic.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}