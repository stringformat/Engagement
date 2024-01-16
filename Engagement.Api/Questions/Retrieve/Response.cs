using Engagement.Application.Features.Campaigns.Retrieve;

namespace Engagement.Api.Questions.Retrieve;

public record Response(Guid Id, string Name, string Description)
{
    public static Response FromQuery(RetrieveCampaignResponse response) =>
        new(response.Id, response.Name, response.Description);
}