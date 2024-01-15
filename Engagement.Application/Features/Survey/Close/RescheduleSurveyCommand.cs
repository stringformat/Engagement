using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Survey.Close;

public record CloseSurveyCommand(Guid Id) : IRequest<Result<Guid>>;