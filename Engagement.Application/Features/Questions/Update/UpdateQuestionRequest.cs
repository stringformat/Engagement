namespace Engagement.Application.Features.Questions.Update;

public record UpdateQuestionRequest(Guid Id, string Name, string Description) : IRequest;