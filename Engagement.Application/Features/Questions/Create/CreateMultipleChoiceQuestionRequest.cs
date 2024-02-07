namespace Engagement.Application.Features.Questions.Create;

public record CreateMultipleChoiceQuestionRequest(Guid SurveyId, string Name, string Description, uint Order, IReadOnlyCollection<CreateMultipleChoiceQuestionRequest.Option> Options) : IRequest
{
    public record Option(uint Order, string Description);
}