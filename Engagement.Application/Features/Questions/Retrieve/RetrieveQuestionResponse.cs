namespace Engagement.Application.Features.Questions.Retrieve;

public record RetrieveQuestionResponse(Guid Id, string Name, string Description, uint Order, RetrieveQuestionResponse.AnswerResponse Answer)
{
    public record AnswerResponse(string Value, string Commentary);
}