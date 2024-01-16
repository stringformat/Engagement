namespace Engagement.Infrastructure.Campaigns;

public class CampaignRepository(DbContext context) : RepositoryBase<Domain.CampaignAggregate.Campaign>(context), ICampaignRepository;