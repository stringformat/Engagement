namespace Engagement.Application.Features.Surveys.Reschedule;

public record RescheduleSurveyRequest(Guid Id, DateTimeOffset SendingDate) : IRequest;