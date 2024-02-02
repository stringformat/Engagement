using System.Collections.Immutable;

namespace Engagement.Application.Features.Questions.Retrieve;

public record RetrieveQuestionResponse(Guid Id, string Name, string Description, uint Order, ImmutableList<RetrieveQuestionResponse.AnswerResponse> Answer)
{
    public abstract record AnswerResponse(string Commentary, Guid UserId, DateTimeOffset Date);
    
    public record TextAnswerResponse(string Value, string Commentary, Guid UserId, DateTimeOffset Date) : AnswerResponse(Commentary, UserId, Date);
    
    public record RangeAnswerResponse(uint Value, string Commentary, Guid UserId, DateTimeOffset Date) : AnswerResponse(Commentary, UserId, Date);
    
    public record MultipleChoiceAnswerResponse(Guid Value, string Commentary, Guid UserId, DateTimeOffset Date) : AnswerResponse(Commentary, UserId, Date);
}