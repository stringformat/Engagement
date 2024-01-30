using MediatR;

namespace Engagement.Application.Features.Campaigns.Create;

public record CreateCampaignCommand(string Name, string Description) : IRequest<Result<Guid>>;