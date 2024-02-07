namespace Engagement.Application.Features.Surveys.Analyze;

public record AnalyzeSurveyRequest(Guid Id, int AgeMin, int AgeMax, Gender Gender) : IRequest;