using MediatR;

namespace Engagement.Application.Features.Questions.Create;

public record CreateMultipleChoiceQuestionCommand(Guid SurveyId, string Name, string Description, uint Order, IReadOnlyCollection<CreateMultipleChoiceQuestionCommand.Option> Options)
    : IRequest<Result<Guid>>
{
    public record Option(uint Order, string Description);
}