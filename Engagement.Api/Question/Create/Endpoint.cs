using Engagement.Application.Features.Campaign.Create;
using MediatR;

namespace Engagement.Api.Question.Create;

public static class Endpoint
{
    public static WebApplication MapQuestionCreate(this WebApplication app)
    {
        app.MapPost("api/surveys/{surveyId:guid}/questions", async (Guid surveyId, Request request, IMediator mediator) =>
        {
            var result = await mediator.Send(new CreateCampaignCommand(request.Name, request.Description));
            
            return result.IsSuccess 
                ? Results.Ok(Response.FromCommand(result)) 
                : Results.BadRequest();
        });

        return app;
    }
}