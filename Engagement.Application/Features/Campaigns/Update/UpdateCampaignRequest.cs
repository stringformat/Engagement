namespace Engagement.Application.Features.Campaigns.Update;

public record UpdateCampaignRequest(Guid Id, string Name, string Description) : IRequest;