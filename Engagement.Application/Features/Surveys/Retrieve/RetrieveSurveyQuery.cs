using MediatR;

namespace Engagement.Application.Features.Surveys.Retrieve;

public record RetrieveSurveyQuery(Guid CampaignId, Guid Id) : IRequest<Result<RetrieveSurveyResponse>>;