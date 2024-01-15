using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Question.Update;

public record UpdateQuestionCommand(Guid Id, string Name, string Description) : IRequest<Result<Guid>>;