using MediatR;

namespace Engagement.Application.Features.Questions.Create;

public record CreateRangeQuestionCommand(Guid SurveyId, string Name, string Description, uint Order) : IRequest<Result<Guid>>;