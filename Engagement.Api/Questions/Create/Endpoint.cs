using Engagement.Application.Features.Questions.Create;

namespace Engagement.Api.Questions.Create;

public static class Endpoint
{
    public static WebApplication MapQuestionCreate(this WebApplication app)
    {
        app.MapPost("api/surveys/{surveyId:guid}/questions", async (Guid surveyId, Request request, IMediator mediator) =>
        {
            var result = await mediator.Send(new CreateQuestionCommand(surveyId, request.Name, request.Description, request.Order));
            
            return result.IsSuccess 
                ? Results.Ok(Response.FromCommand(result)) 
                : Results.BadRequest();
        });

        return app;
    }
}