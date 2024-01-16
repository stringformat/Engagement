using Engagement.Domain.SurveyAggregate;

namespace Engagement.Application.Features.Surveys.List;

public record ListSurveyResponse(Guid Id, string Name, string Description, DateTimeOffset SendingDate, Status Status);