using Engagement.Application.Features.Surveys.Retrieve;

namespace Engagement.Api.Surveys.Retrieve;

public record Response(Guid Id, string Name, string Description)
{
    public static Response FromQuery(RetrieveSurveyResponse response) =>
        new(response.Id, response.Name, response.Description);
}