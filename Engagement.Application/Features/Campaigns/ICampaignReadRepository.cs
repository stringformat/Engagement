using Engagement.Application.Features.Campaigns.List;
using Engagement.Application.Features.Campaigns.Retrieve;

namespace Engagement.Application.Features.Campaigns;

public interface ICampaignReadRepository
{
    Task<List<ListCampaignResponse>> ListAsync(CancellationToken cancellationToken);
    Task<Result<RetrieveCampaignResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken);
}