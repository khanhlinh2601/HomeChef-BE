namespace HC.Domain.Dto.Responses;

public class NotificationResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public Guid ReceiverId { get; set; }
    public DateTime SentTime { get; set; }
}

