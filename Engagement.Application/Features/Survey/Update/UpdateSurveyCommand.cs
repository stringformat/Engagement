using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Survey.Update;

public record UpdateSurveyCommand(Guid CampaignId, Guid Id, string Name, string Description) : IRequest<Result<Guid>>;