namespace Engagement.Application.Features.Campaigns.Create;

public record CreateCampaignRequest(string Name, string Description) : IRequest;