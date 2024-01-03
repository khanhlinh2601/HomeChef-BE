using HC.Application.Interfaces;
using HC.Domain.Dto.Requests;
using HC.Domain.Dto.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HC.API.Controllers;

public class FeedbackController : BaseApiController
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateFeedbackRequest request)
    {
        return Ok(await _feedbackService.Create(request));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FeedbackResponse>>> GetAll()
    {
        return Ok(await _feedbackService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FeedbackResponse>> GetById(Guid id)
    {
        return Ok(await _feedbackService.GetById(id));
    }

    [HttpGet("chef/{chefId}")]

    public async Task<ActionResult<IEnumerable<FeedbackResponse>>> GetByChefId(Guid chefId)
    {
        return Ok(await _feedbackService.GetByChefId(chefId));
    }
    

}