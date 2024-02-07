using Engagement.Application.Features.Surveys.Update;

namespace Engagement.Api.Surveys.Update;

public static class Endpoint
{
    public static WebApplication MapSurveyUpdate(this WebApplication app)
    {
        app.MapPut("api/surveys/{id:guid}", async (Guid id, Request request, UpdateSurveyCommand updateSurveyCommand, CancellationToken cancellationToken) =>
        {
            var response =
                await updateSurveyCommand.Handle(new UpdateSurveyRequest(id, request.Name, request.Description),
                    cancellationToken);
            
            return response.IsSuccess 
                ? Results.Ok() 
                : response.Error.ToResponse();
        });

        return app;
    }
}