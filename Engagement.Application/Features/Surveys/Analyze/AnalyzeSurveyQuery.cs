using MediatR;

namespace Engagement.Application.Features.Surveys.Analyze;

public record AnalyzeSurveyQuery(Guid Id) : IRequest<Result<AnalyzeSurveyResponse>>;