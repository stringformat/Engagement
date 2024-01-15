using Engagement.Domain.SurveyAggregate;

namespace Engagement.Application.Features.Survey.Retrieve;

public record RetrieveSurveyResponse(Guid Id, string Name, string Description, DateTimeOffset SendingDate, Status Status);