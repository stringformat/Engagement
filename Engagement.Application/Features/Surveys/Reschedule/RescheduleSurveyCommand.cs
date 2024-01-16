using MediatR;

namespace Engagement.Application.Features.Surveys.Reschedule;

public record RescheduleSurveyCommand(Guid CampaignId, Guid Id, DateTimeOffset SendingDate)
    : IRequest<Result<RescheduleSurveyResponse>>;