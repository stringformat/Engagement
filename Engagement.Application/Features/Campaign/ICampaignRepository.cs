using Engagement.Common.ResultPattern;

namespace Engagement.Application.Features.Campaign;

public interface ICampaignRepository
{
    Task AddAsync(Domain.CampaignAggregate.Campaign entity, CancellationToken cancellationToken);
    void Update(Domain.CampaignAggregate.Campaign entity);
    Task<Result<Domain.CampaignAggregate.Campaign>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}