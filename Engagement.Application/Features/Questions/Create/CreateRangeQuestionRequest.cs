namespace Engagement.Application.Features.Questions.Create;

public record CreateRangeQuestionRequest(Guid SurveyId, string Name, string Description, uint Order) : IRequest;