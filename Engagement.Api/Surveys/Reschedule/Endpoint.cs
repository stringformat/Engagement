using Engagement.Application.Features.Surveys.Reschedule;

namespace Engagement.Api.Surveys.Reschedule;

public static class Endpoint
{
    public static WebApplication MapSurveyReschedule(this WebApplication app)
    {
        app.MapPost("api/surveys/{id:guid}/reschedule", async (Guid id, Request request, RescheduleSurveyCommand rescheduleSurveyCommand, CancellationToken cancellationToken) =>
        {
            var response = await rescheduleSurveyCommand.Handle(new RescheduleSurveyRequest(id, request.SendingDate),
                cancellationToken);
            
            return response.IsSuccess 
                ? Results.Ok() 
                : response.Error.ToResponse();
        });

        return app;
    }
}