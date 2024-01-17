namespace Engagement.Infrastructure.Campaigns;

public class CampaignRepository(EngagementContext context) : RepositoryBase<Domain.CampaignAggregate.Campaign>(context), ICampaignRepository;