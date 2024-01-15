using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Question.Create;

public record CreateQuestionCommand(Guid SurveyId, string Name, string Description, uint Order) : IRequest<Result<Guid>>;