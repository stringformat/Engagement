using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Survey.Reschedule;

public record RescheduleSurveyCommand(Guid CampaignId, Guid Id, DateTimeOffset SendingDate)
    : IRequest<Result<RescheduleSurveyResponse>>;