using System.Collections.Immutable;
using Engagement.Application.Features.Questions.Retrieve;

namespace Engagement.Api.Questions.Retrieve;

public record Response(Guid Id, string Name, string Description, uint Order, ImmutableList<AnswerResponse> Answers)
{
    public static Response FromQuery(RetrieveQuestionResponse response) =>
        new(response.Id, response.Name, response.Description, response.Order, response.Answers.Select(MapToAnswerResponse).ToImmutableList());
    
    private static AnswerResponse MapToAnswerResponse(RetrieveQuestionResponse.AnswerResponse answer)
    {
        return answer switch
        {
            RetrieveQuestionResponse.EmptyAnswerResponse empty => EmptyAnswerResponse.FromResponse(empty),
            RetrieveQuestionResponse.TextAnswerResponse text => TextAnswerResponse.FromResponse(text),
            RetrieveQuestionResponse.RangeAnswerResponse range => RangeAnswerResponse.FromResponse(range),
            RetrieveQuestionResponse.MultipleChoiceAnswerResponse multipleChoice => MultipleChoiceAnswerResponse.FromResponse(multipleChoice),
            _ => throw new ArgumentOutOfRangeException(nameof(answer), answer, null)
        };
    }
}

public abstract record AnswerResponse(Guid Id, string Commentary, Guid UserId, DateTimeOffset Date);

public record EmptyAnswerResponse(Guid Id, Guid UserId, DateTimeOffset Date)
    : AnswerResponse(Id, string.Empty, UserId, Date)
{
    public static EmptyAnswerResponse FromResponse(RetrieveQuestionResponse.EmptyAnswerResponse response) =>
        new(response.Id, response.Id, response.Date);
}

public record TextAnswerResponse(Guid Id, string Value, string Commentary, Guid UserId, DateTimeOffset Date)
    : AnswerResponse(Id, Commentary, UserId, Date)
{
    public static TextAnswerResponse FromResponse(RetrieveQuestionResponse.TextAnswerResponse response) =>
        new(response.Id, response.Value, response.Commentary, response.UserId, response.Date);
}

public record RangeAnswerResponse(Guid Id, uint Value, string Commentary, Guid UserId, DateTimeOffset Date)
    : AnswerResponse(Id, Commentary, UserId, Date)
{
    public static RangeAnswerResponse FromResponse(RetrieveQuestionResponse.RangeAnswerResponse response) =>
        new(response.Id, response.Value, response.Commentary, response.UserId, response.Date);
}

public record MultipleChoiceAnswerResponse(Guid Id, Guid Value, string Commentary, Guid UserId, DateTimeOffset Date)
    : AnswerResponse(Id, Commentary, UserId, Date)
{
    public static MultipleChoiceAnswerResponse FromResponse(RetrieveQuestionResponse.MultipleChoiceAnswerResponse response) =>
        new(response.Id, response.Value, response.Commentary, response.UserId, response.Date);
}