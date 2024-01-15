using Engagement.Application.Features.Campaign.List;

namespace Engagement.Api.Survey.List;

public record Response(Guid Id, string Name, string Description)
{
    public static Response FromQuery(ListCampaignResponse response) =>
        new(response.Id, response.Name, response.Description);
}