using MediatR;

namespace Engagement.Application.Features.Surveys.Update;

public record UpdateSurveyCommand(Guid CampaignId, Guid Id, string Name, string Description) : IRequest<Result<Guid>>;