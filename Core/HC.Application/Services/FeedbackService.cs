using HC.Application.Common.Persistence;
using HC.Application.Specification;
using Microsoft.Extensions.Localization;

namespace HC.Application.Services;

public class FeedbackService : IFeedbackService
{
    private readonly IRepository<Feedback> _feedbackRepository;
    private readonly IStringLocalizer<FeedbackService> _t;

    public FeedbackService(IRepository<Feedback> feedbackRepository, IStringLocalizer<FeedbackService> t)
    {
        _feedbackRepository = feedbackRepository;
        _t = t;
    }

    public async Task<Guid> Create(CreateFeedbackRequest request)
    {
        var entity = request.Adapt<Feedback>();

        await _feedbackRepository.AddAsync(entity);
        return entity.Id;
    }

    public async Task<IEnumerable<FeedbackResponse>> GetAll()
    {
        var feedbacks = await _feedbackRepository.ListAsync();
        return feedbacks.Adapt<IEnumerable<FeedbackResponse>>();
    }

    public async Task<FeedbackResponse> GetById(Guid id)
    {
        var feedback = await _feedbackRepository.GetByIdAsync(id);
        _ = feedback ?? throw new NotFoundException(_t["Feedback not found"]);
        return feedback.Adapt<FeedbackResponse>();
    }

    public async Task<IEnumerable<FeedbackResponse>> GetByChefId(Guid chefId)
    {
        var feedbacks = await _feedbackRepository.ListAsync(new FeedbackByChefIdSpec(chefId));
        return feedbacks.Adapt<IEnumerable<FeedbackResponse>>();
    }

    //delete
    public async Task<Guid> Delete(Guid id)
    {
        var feedback = await _feedbackRepository.GetByIdAsync(id);
        _ = feedback ?? throw new NotFoundException(_t["Feedback not found"]);
        await _feedbackRepository.DeleteAsync(feedback);
        return feedback.Id;
    }



}