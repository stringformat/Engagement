namespace Engagement.Application.Features.Questions.Reply;

public record ReplyQuestionRequest(Guid Id, ReplyQuestionRequest.AnswerRequest Answer) : IRequest
{
    public abstract record AnswerRequest(string? Commentary, Guid UserId);
    
    public record TextAnswerRequest(string Value, string? Commentary, Guid UserId) : AnswerRequest(Commentary, UserId);
    
    public record RangeAnswerRequest(uint Value, string? Commentary, Guid UserId) : AnswerRequest(Commentary, UserId);
    
    public record MultipleChoiceAnswerRequest(Guid Value, string? Commentary, Guid UserId) : AnswerRequest(Commentary, UserId);
}