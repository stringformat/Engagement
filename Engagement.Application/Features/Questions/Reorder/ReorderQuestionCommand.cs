using MediatR;

namespace Engagement.Application.Features.Questions.Reorder;

public record ReorderQuestionCommand(Guid Id, uint Order) : IRequest<Result<ReorderQuestionResponse>>;