using System.Collections.Immutable;

namespace Engagement.Application.Features.Questions.Retrieve;

public record RetrieveQuestionResponse(Guid Id, string Name, string Description, uint Order, ImmutableList<RetrieveQuestionResponse.AnswerResponse> Answer)
{
    public record AnswerResponse(string Value, string Commentary, Guid UserId, DateTimeOffset Date);
}