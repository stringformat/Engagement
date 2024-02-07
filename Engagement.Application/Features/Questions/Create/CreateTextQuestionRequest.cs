namespace Engagement.Application.Features.Questions.Create;

public record CreateTextQuestionRequest(Guid SurveyId, string Name, string Description, uint Order) : IRequest;