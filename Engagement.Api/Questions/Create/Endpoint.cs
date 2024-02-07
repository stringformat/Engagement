using Engagement.Application.Features.Questions.Create;

namespace Engagement.Api.Questions.Create;

public static class Endpoint
{
    public static WebApplication MapQuestionCreate(this WebApplication app)
    {
        app.MapPost("api/surveys/{surveyId:guid}/questions", async (
            Guid surveyId, 
            Request request, 
            CreateTextQuestionCommand createTextQuestionCommand,
            CreateRangeQuestionCommand createRangeQuestionCommand,
            CreateMultipleChoiceQuestionCommand createMultipleChoiceQuestionCommand, 
            CancellationToken cancellationToken) =>
        {
            var response = request switch
            {
                MultipleChoiceRequest multipleChoice => await createMultipleChoiceQuestionCommand.Handle(multipleChoice.ToCommandRequest(surveyId), cancellationToken),
                RangeRequest range => await createRangeQuestionCommand.Handle(range.ToCommandRequest(surveyId), cancellationToken),
                TextRequest text => await createTextQuestionCommand.Handle(text.ToCommandRequest(surveyId), cancellationToken),
                _ => throw new ArgumentOutOfRangeException(nameof(request))
            };

            return response.IsSuccess
                ? Results.Ok(Response.FromCommand(response.Value)) 
                : response.Error.ToResponse();
        });

        return app;
    }
}