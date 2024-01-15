namespace Engagement.Application.Features.Question.List;

public record ListQuestionResponse(Guid Id, string Name, string Description, uint Order);