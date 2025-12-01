using CodeChallenge.Api.Logic;
using CodeChallenge.Api.Models;
using CodeChallenge.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Api.Controllers;

[ApiController]
[Route("api/v1/organizations/{organizationId}/messages")]
public class MessagesController : ControllerBase
{
    private readonly IMessageLogic _messageLogic;

    // Fixed: Depends on IMessageLogic, not IMessageRepository (separation of concerns)
    public MessagesController(IMessageLogic messageLogic)
    {
        _messageLogic = messageLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Message>> Create([FromBody] Message message)
    {
        var created = await _messageLogic.CreateMessageAsync(message);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> Get(Guid id)
    {
        var message = await _messageLogic.GetMessageAsync(id);
        if (message == null) return NotFound();
        return Ok(message);
    }

   
    [HttpPut("{id}")]
    public async Task<ActionResult<Message>> Update(Guid id, [FromBody] UpdateMessageDto dto)
    {
        var updated = await _messageLogic.UpdateMessageAsync(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _messageLogic.DeleteMessageAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }


}
