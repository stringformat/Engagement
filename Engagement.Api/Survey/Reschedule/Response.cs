using Engagement.Application.Features.Survey.Reschedule;

namespace Engagement.Api.Survey.Reschedule;

public record Response(Guid Id, DateTimeOffset SendingDate)
{
    public static Response FromCommand(RescheduleSurveyResponse response)
        => new(response.Id, response.SendingDate);
}