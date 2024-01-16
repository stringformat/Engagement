using MediatR;

namespace Engagement.Application.Features.Questions.Update;

public record UpdateQuestionCommand(Guid Id, string Name, string Description) : IRequest<Result<Guid>>;