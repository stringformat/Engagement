using System.Collections.Immutable;

namespace Engagement.Application.Features.Questions.Retrieve;

public record RetrieveQuestionResponse(Guid Id, string Name, string Description, uint Order, ImmutableList<RetrieveQuestionResponse.AnswerResponse> Answers)
{
    public abstract record AnswerResponse(Guid Id, string Commentary, Guid UserId, DateTimeOffset Date);
    
    public record EmptyAnswerResponse(Guid Id, Guid UserId, DateTimeOffset Date) : AnswerResponse(Id, string.Empty, UserId, Date);
    
    public record TextAnswerResponse(Guid Id, string Value, string Commentary, Guid UserId, DateTimeOffset Date) : AnswerResponse(Id, Commentary, UserId, Date);
    
    public record RangeAnswerResponse(Guid Id, uint Value, string Commentary, Guid UserId, DateTimeOffset Date) : AnswerResponse(Id, Commentary, UserId, Date);
    
    public record MultipleChoiceAnswerResponse(Guid Id, Guid Value, string Commentary, Guid UserId, DateTimeOffset Date) : AnswerResponse(Id, Commentary, UserId, Date);
}