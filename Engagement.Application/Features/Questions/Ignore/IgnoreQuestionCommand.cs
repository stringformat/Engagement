using MediatR;

namespace Engagement.Application.Features.Questions.Ignore;

public record IgnoreQuestionCommand(Guid Id, Guid UserId) : IRequest<Result>;