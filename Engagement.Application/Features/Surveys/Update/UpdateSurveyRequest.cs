namespace Engagement.Application.Features.Surveys.Update;

public record UpdateSurveyRequest(Guid Id, string Name, string Description) : IRequest;