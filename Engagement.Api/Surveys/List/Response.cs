using Engagement.Application.Features.Surveys.List;
using Engagement.Domain.SurveyAggregate;

namespace Engagement.Api.Surveys.List;

public record Response(Guid Id, string Name, string Description, DateTimeOffset SendingDate, Status Status)
{
    public static Response FromQuery(ListSurveyResponse response) =>
        new(response.Id, response.Name, response.Description, response.SendingDate, response.Status);
}