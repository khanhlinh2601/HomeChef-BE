namespace HC.Domain.Dto.Responses;

public class FeedbackResponse
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserResponse CreatedBy { get; set; } = null!;
}