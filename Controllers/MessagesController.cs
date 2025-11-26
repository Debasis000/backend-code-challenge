using CodeChallenge.Api.Logic;
using CodeChallenge.Api.Models;
using CodeChallenge.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Api.Controllers;

[ApiController]
[Route("api/v1/organizations/{organizationId}/messages")]
public class MessagesController : ControllerBase
{
    private readonly IMessageRepository _repository;
    private readonly IMessageLogic _logic;
    private readonly ILogger<MessagesController> _logger;

    public MessagesController(IMessageRepository repository, IMessageLogic messageLogic, ILogger<MessagesController> logger)
    {
        _repository = repository;
        _logic = messageLogic;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> GetAll(Guid organizationId)
    {
        try
        {
            var messages = await _repository.GetAllByOrganizationAsync(organizationId);
            return Ok(messages);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving messages for organization {OrganizationId}", organizationId);
            return StatusCode(500, "An error occurred while retrieving messages.");
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> Get(Guid organizationId, Guid id)
    {
        try
        {
            var message = await _repository.GetByIdAsync(organizationId, id);
            return message is null ? NotFound() : Ok(message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving messages for organization {OrganizationId} and {id}", organizationId, id);
            return StatusCode(500, "An error occurred while retrieving the message.");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Message>> Create(Guid organizationId, CreateMessageRequest request)
    {
        try
        {
            var message = new Message
            {
                OrganizationId = organizationId,
                Title = request.Title,
                Content = request.Content ?? string.Empty,
                IsActive = true
            };

            var created = await _repository.CreateAsync(message);

            return CreatedAtAction(
                nameof(Get),
                new { organizationId, id = created.Id },
                created);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating a message for organization {OrganizationId}", organizationId);
            return StatusCode(500, "An error occurred while creating the message.");
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid organizationId, Guid id, Message message)
    {
        try
        {
            if (id != message.Id)
            {
                return BadRequest("Message ID mismatch.");
            }

            message.OrganizationId = organizationId;

            var updatedMessage = await _repository.UpdateAsync(message);

            if (updatedMessage == null)
            {
                return NotFound("Message not found.");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating the message {MessageId} for organization {OrganizationId}", id, organizationId);
            return StatusCode(500, "An error occurred while updating the message.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid organizationId, Guid id)
    {
        try
        {
            var deleted = await _repository.DeleteAsync(organizationId, id);

            if (!deleted)
            {
                return NotFound("Message not found.");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting the message {MessageId} for organization {OrganizationId}", id, organizationId);
            return StatusCode(500, "An error occurred while deleting the message.");
        }
    }

     
}
