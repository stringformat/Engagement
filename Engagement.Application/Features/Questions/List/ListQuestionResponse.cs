namespace Engagement.Application.Features.Questions.List;

public record ListQuestionResponse(Guid Id, string Name, string Description, uint Order);