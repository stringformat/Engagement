using Engagement.Application.Features.Surveys.Reschedule;

namespace Engagement.Api.Surveys.Reschedule;

public record Response(Guid Id, DateTimeOffset SendingDate)
{
    public static Response FromCommand(RescheduleSurveyResponse response)
        => new(response.Id, response.SendingDate);
}