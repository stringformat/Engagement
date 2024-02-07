namespace Engagement.Application.Features.Questions.Reorder;

public record ReorderQuestionRequest(Guid Id, uint Order) : IRequest;