using MediatR;

namespace Engagement.Application.Features.Survey.List;

public record ListSurveyQuery : IRequest<List<ListSurveyResponse>>;