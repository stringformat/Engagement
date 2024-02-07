namespace Engagement.Application.Features.Questions.Skip;

public record SkipQuestionRequest(Guid Id, Guid UserId) : IRequest;