namespace Engagement.Application.Features.Questions.Ignore;

public record IgnoreQuestionRequest(Guid Id, Guid UserId) : IRequest;