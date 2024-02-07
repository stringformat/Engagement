using System.Text.Json.Serialization;
using Engagement.Application.Features.Questions.Reply;

namespace Engagement.Api.Questions.Reply;

[JsonPolymorphic]
[JsonDerivedType(typeof(TextRequest))]
[JsonDerivedType(typeof(RangeRequest))]
[JsonDerivedType(typeof(MultipleChoiceRequest))]
public abstract record Request(string? Commentary, Guid UserId)
{
    public abstract ReplyQuestionRequest ToCommandRequest(Guid questionId);
}

public record TextRequest(string Value, string? Commentary, Guid UserId) : Request(Commentary, UserId)
{
    public override ReplyQuestionRequest ToCommandRequest(Guid questionId) 
        => new (questionId, new ReplyQuestionRequest.TextAnswerRequest(Value, Commentary, UserId));
}

public record RangeRequest(uint Score, string? Commentary, Guid UserId) : Request(Commentary, UserId)
{
    public override ReplyQuestionRequest ToCommandRequest(Guid questionId) 
        => new(questionId, new ReplyQuestionRequest.RangeAnswerRequest(Score, Commentary, UserId));
}

public record MultipleChoiceRequest(Guid SelectedOptionId, string? Commentary, Guid UserId) : Request(Commentary, UserId)
{
    public override ReplyQuestionRequest ToCommandRequest(Guid questionId) 
        => new (questionId, new ReplyQuestionRequest.MultipleChoiceAnswerRequest(SelectedOptionId, Commentary, UserId));
}

