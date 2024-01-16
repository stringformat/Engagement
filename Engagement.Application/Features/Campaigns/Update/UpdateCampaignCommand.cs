using MediatR;

namespace Engagement.Application.Features.Campaigns.Update;

public record UpdateCampaignCommand(Guid Id, string Name, string Description) : IRequest<Result<Guid>>;