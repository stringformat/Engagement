namespace Engagement.Api.Questions.Create;

public static class Endpoint
{
    public static WebApplication MapQuestionCreate(this WebApplication app)
    {
        app.MapPost("api/surveys/{surveyId:guid}/questions", async (Guid surveyId, Request request, IMediator mediator) =>
        {
            var response = await mediator.Send(request.ToCommand(surveyId));
            
            return response.IsSuccess
                ? Results.Ok(Response.FromCommand(response.Value)) 
                : response.Error.ToResponse();
        });

        return app;
    }
}