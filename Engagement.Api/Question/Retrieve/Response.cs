using Engagement.Application.Features.Campaign.Retrieve;

namespace Engagement.Api.Question.Retrieve;

public record Response(Guid Id, string Name, string Description)
{
    public static Response FromQuery(RetrieveCampaignResponse response) =>
        new(response.Id, response.Name, response.Description);
}