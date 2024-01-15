using MediatR;

namespace Engagement.Application.Features.Question.List;

public record ListQuestionQuery(Guid SurveyId) : IRequest<List<ListQuestionResponse>>;