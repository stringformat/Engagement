using Engagement.Application.Features.Survey.Retrieve;

namespace Engagement.Api.Survey.Retrieve;

public record Response(Guid Id, string Name, string Description)
{
    public static Response FromQuery(RetrieveSurveyResponse response) =>
        new(response.Id, response.Name, response.Description);
}