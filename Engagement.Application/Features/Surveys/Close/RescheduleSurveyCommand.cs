using MediatR;

namespace Engagement.Application.Features.Surveys.Close;

public record CloseSurveyCommand(Guid Id) : IRequest<Result<Guid>>;