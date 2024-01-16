using MediatR;

namespace Engagement.Application.Features.Questions.List;

public record ListQuestionQuery : IRequest<List<ListQuestionResponse>>;