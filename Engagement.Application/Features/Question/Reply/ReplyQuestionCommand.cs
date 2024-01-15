using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Question.Reply;

public record ReplyQuestionCommand(Guid Id, ReplyQuestionCommand.AnswerCommand Answer) : IRequest<Result<Guid>>
{
    public record AnswerCommand(string Value, string? Commentary, Guid UserId);
}