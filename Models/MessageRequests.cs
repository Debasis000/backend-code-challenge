using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Api.Models;

public class CreateMessageRequest
{
    [Required]
    [MaxLength(500)]
    public string Content { get; set; }
    public string Title { get; set; } = string.Empty;
   
}

public class UpdateMessageRequest
{
    public string Title { get; set; } = string.Empty;
    [Required]
    [MaxLength(500)]
    public string Content { get; set; }
    public bool IsActive { get; set; }
}
