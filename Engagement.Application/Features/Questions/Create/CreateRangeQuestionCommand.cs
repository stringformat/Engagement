using Engagement.Domain.QuestionAggregate;
using MediatR;

namespace Engagement.Application.Features.Questions.Create;

public record CreateRangeQuestionCommand(Guid SurveyId, string Name, string Description, uint Order, Pillar Pillar) : IRequest<Result<Guid>>;