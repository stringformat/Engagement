using Engagement.Application.Features.Campaigns.List;

namespace Engagement.Api.Questions.List;

public record Response(Guid Id, string Name, string Description)
{
    public static Response FromQuery(ListCampaignResponse response) =>
        new(response.Id, response.Name, response.Description);
}