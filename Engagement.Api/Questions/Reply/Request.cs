using System.Text.Json.Serialization;
using Engagement.Application.Features.Questions.Reply;

namespace Engagement.Api.Questions.Reply;

[JsonPolymorphic]
[JsonDerivedType(typeof(TextRequest))]
[JsonDerivedType(typeof(RangeRequest))]
[JsonDerivedType(typeof(MultipleChoiceRequest))]
public abstract record Request(string? Commentary, Guid UserId)
{
    public abstract ReplyQuestionCommand.AnswerCommand ToCommand();
}

public record TextRequest(string Value, string? Commentary, Guid UserId) : Request(Commentary, UserId)
{
    public override ReplyQuestionCommand.AnswerCommand ToCommand() 
        => new ReplyQuestionCommand.TextAnswerCommand(Value, Commentary, UserId);
}

public record RangeRequest(uint Score, string? Commentary, Guid UserId) : Request(Commentary, UserId)
{
    public override ReplyQuestionCommand.AnswerCommand ToCommand() 
        => new ReplyQuestionCommand.RangeAnswerCommand(Score, Commentary, UserId);
}

public record MultipleChoiceRequest(Guid SelectedOptionId, string? Commentary, Guid UserId) : Request(Commentary, UserId)
{
    public override ReplyQuestionCommand.AnswerCommand ToCommand() 
        => new ReplyQuestionCommand.MultipleChoiceAnswerCommand(SelectedOptionId, Commentary, UserId);
}

