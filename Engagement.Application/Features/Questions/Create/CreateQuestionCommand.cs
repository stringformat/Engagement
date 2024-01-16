using MediatR;

namespace Engagement.Application.Features.Questions.Create;

public record CreateQuestionCommand(Guid SurveyId, string Name, string Description, uint Order) : IRequest<Result<Guid>>;