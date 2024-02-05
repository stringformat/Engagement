using Engagement.Application.Features.Campaigns;
using MediatR;

namespace Engagement.Application.Features.Surveys.Analyze;

public record AnalyzeSurveyQueryHandler : IRequestHandler<AnalyzeSurveyQuery, Result<AnalyzeSurveyResponse>>
{
    private readonly ICampaignReadRepository _repository;

    public AnalyzeSurveyQueryHandler(ICampaignReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AnalyzeSurveyResponse>> Handle(AnalyzeSurveyQuery request, CancellationToken cancellationToken)
    {
        return await _repository.RetrieveAsync(request.Id, cancellationToken);
    }
}