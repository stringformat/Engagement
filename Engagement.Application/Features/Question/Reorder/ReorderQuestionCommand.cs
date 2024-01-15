using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Question.Reorder;

public record ReorderQuestionCommand(Guid Id, uint Order) : IRequest<Result<ReorderQuestionResponse>>;