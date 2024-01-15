using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Survey.Create;

public record CreateSurveyCommand(Guid CampaignId, string Name, string Description, DateTimeOffset SendingDate) : IRequest<Result<Guid>>;