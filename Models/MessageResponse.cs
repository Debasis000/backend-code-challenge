namespace CodeChallenge.Api.Models
{
    public class MessageResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string OrganizationId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
