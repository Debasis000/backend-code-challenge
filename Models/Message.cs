using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Api.Models;

public class Message
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(500)]
    public string Content { get; set; }

  
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
}


public class UpdateMessageDto
{
    [Required]
    public string Content { get; set; } = string.Empty;
}