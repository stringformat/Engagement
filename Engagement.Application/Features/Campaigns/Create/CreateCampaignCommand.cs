using MediatR;

namespace Engagement.Application.Features.Campaigns.Create;

public record CreateCampaignCommand(string Name, string Description, HashSet<Guid> Populations) : IRequest<Result<Guid>>;