using MediatR;

namespace Engagement.Application.Features.Questions.Reply;

public record ReplyQuestionCommand(Guid Id, ReplyQuestionCommand.AnswerCommand Answer) : IRequest<Result<Guid>>
{
    public abstract record AnswerCommand(string? Commentary, Guid UserId);
    
    public record TextAnswerCommand(string Value, string? Commentary, Guid UserId) : AnswerCommand(Commentary, UserId);
    
    public record RangeAnswerCommand(uint Value, string? Commentary, Guid UserId) : AnswerCommand(Commentary, UserId);
    
    public record MultipleChoiceAnswerCommand(Guid OptionId, string? Commentary, Guid UserId) : AnswerCommand(Commentary, UserId);
}