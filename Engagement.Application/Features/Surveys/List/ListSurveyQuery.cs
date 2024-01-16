using MediatR;

namespace Engagement.Application.Features.Surveys.List;

public record ListSurveyQuery : IRequest<List<ListSurveyResponse>>;