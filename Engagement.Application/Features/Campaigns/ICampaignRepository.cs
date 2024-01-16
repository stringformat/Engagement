namespace Engagement.Application.Features.Campaigns;

public interface ICampaignRepository
{
    Task AddAsync(Domain.CampaignAggregate.Campaign entity, CancellationToken cancellationToken);
    void Update(Domain.CampaignAggregate.Campaign entity);
    Task<Result<Domain.CampaignAggregate.Campaign>> FindAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Domain.CampaignAggregate.Campaign>> FindAsync(HashSet<Guid> ids, CancellationToken cancellationToken);
}