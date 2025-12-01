using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Api.Models;

public class Message
{
    public Guid Id { get; set; }
    public Guid OrganizationId { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 200 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Content is required.")]
    public string Content { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}


public class UpdateMessageDto
{
    [Required]
    public string Content { get; set; } = string.Empty;
}