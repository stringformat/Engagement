using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Survey.Retrieve;

public record RetrieveSurveyQuery(Guid CampaignId, Guid Id) : IRequest<Result<RetrieveSurveyResponse>>;