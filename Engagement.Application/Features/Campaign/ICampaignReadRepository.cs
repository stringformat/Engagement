using Engagement.Application.Features.Campaign.List;
using Engagement.Application.Features.Campaign.Retrieve;
using Engagement.Common.ResultPattern;

namespace Engagement.Application.Features.Campaign;

public interface ICampaignReadRepository
{
    Task<List<ListCampaignResponse>> ListAsync(CancellationToken cancellationToken);
    Task<Result<RetrieveCampaignResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken);
}