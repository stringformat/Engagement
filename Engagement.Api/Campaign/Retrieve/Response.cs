using Engagement.Application.Features.Campaign.Retrieve;

namespace Engagement.Api.Campaign.Retrieve;

public record Response(Guid Id, string Name, string Description)
{
    public static Response FromQuery(RetrieveCampaignResponse response) =>
        new(response.Id, response.Name, response.Description);
}