using Engagement.Application.Features.Questions.Update;

namespace Engagement.Api.Questions.Update;

public static class Endpoint
{
    public static WebApplication MapQuestionUpdate(this WebApplication app)
    {
        app.MapPut("api/questions/{id:guid}", async (Guid id, Request request, UpdateQuestionCommand updateQuestionCommand, CancellationToken cancellationToken) =>
        {
            var response = await updateQuestionCommand.Handle(new UpdateQuestionRequest(id, request.Name, request.Description), cancellationToken);
            
            return response.IsSuccess 
                ? Results.Ok()
                : response.Error.ToResponse();
        });

        return app;
    }
}