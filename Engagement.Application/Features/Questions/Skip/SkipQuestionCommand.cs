using MediatR;

namespace Engagement.Application.Features.Questions.Skip;

public record SkipQuestionCommand(Guid Id, Guid UserId) : IRequest<Result>;