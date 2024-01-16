using MediatR;

namespace Engagement.Application.Features.Campaigns.Retrieve;

public record RetrieveCampaignQuery(Guid Id) : IRequest<Result<RetrieveCampaignResponse>>;