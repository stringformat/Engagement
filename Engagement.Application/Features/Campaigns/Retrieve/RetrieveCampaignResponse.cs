using System.Collections.Immutable;

namespace Engagement.Application.Features.Campaigns.Retrieve;

public record RetrieveCampaignResponse(Guid Id, string Name, string Description, ImmutableList<RetrieveCampaignResponse.SurveyResponse> Surveys)
{
    public record SurveyResponse(Guid Id, string Name, string Description, DateTimeOffset SendingDate);
}