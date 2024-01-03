namespace HC.Application.Interfaces;

public interface IFeedbackService
{
    Task<Guid> Create(CreateFeedbackRequest request);
    Task<IEnumerable<FeedbackResponse>> GetAll();
    Task<FeedbackResponse> GetById(Guid id);
    Task<IEnumerable<FeedbackResponse>> GetByChefId(Guid chefId);
    Task<Guid> Delete(Guid id);
}