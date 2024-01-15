using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Survey.Open;

public record OpenSurveyCommand(Guid CampaignId, Guid Id) : IRequest<Result<Guid>>;