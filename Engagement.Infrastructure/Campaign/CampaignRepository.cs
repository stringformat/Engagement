using Engagement.Application.Features.Campaign;
using Engagement.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Engagement.Infrastructure.Campaign;

public class CampaignRepository(DbContext context) : RepositoryBase<Domain.CampaignAggregate.Campaign>(context), ICampaignRepository;