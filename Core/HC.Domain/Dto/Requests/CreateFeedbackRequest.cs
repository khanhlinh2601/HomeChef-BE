namespace HC.Domain.Dto.Requests;

public class CreateFeedbackRequest
{
    public Guid OrderId { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; } = 1;
}