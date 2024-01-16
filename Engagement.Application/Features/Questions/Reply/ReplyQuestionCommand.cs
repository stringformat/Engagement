using MediatR;

namespace Engagement.Application.Features.Questions.Reply;

public record ReplyQuestionCommand(Guid Id, ReplyQuestionCommand.AnswerCommand Answer) : IRequest<Result<Guid>>
{
    public record AnswerCommand(string Value, string? Commentary, Guid UserId);
}