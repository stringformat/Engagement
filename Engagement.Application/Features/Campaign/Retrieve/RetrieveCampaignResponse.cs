using System.Collections.Immutable;

namespace Engagement.Application.Features.Campaign.Retrieve;

public record RetrieveCampaignResponse(Guid Id, string Name, string Description, ImmutableList<RetrieveCampaignResponse.Survey> Surveys)
{
    public record Survey(Guid Id, string Name, string Description, DateTimeOffset SendingDate);
}