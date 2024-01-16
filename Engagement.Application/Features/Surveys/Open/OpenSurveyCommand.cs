using MediatR;

namespace Engagement.Application.Features.Surveys.Open;

public record OpenSurveyCommand(Guid CampaignId, Guid Id) : IRequest<Result<Guid>>;